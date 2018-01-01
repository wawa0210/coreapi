using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CommonLib;
using DataAccess;
using DataAccess.BaseQuery;
using EmergencyAccount.Etity;
using EmergencyAccount.Etity.Dto;
using Microsoft.EntityFrameworkCore;

namespace EmergencyAccount.Application
{
    /// <summary>
    /// 文物相关
    /// </summary>
    public class AntiquesService : IAntiquesService
    {
        private readonly EfDbContext _context;
        public AntiquesService(EfDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 新增文物信息
        /// </summary>
        /// <param name="entityAntiques"></param>
        /// <returns></returns>
        public async Task AddAntiquesAsync(EntityAntiques entityAntiques)
        {
            var model = new TableAntiques
            {
                Id = Guid.NewGuid().GetGuidStr(),
                Name = entityAntiques.Name,
                MaxClassId = entityAntiques.MaxClassId,
                MinClassId = entityAntiques.MinClassId ?? "",
                AgeInfo = entityAntiques.AgeInfo,
                FeatureInfo = entityAntiques.FeatureInfo,
                UnearthedInfo = entityAntiques.UnearthedInfo,
                BookInfo = entityAntiques.BookInfo,
                Description = entityAntiques.Description,
                VoiceUrl = entityAntiques.VoiceUrl ?? ""
            };
            var listImgUrl = entityAntiques.ListImg.Select(x => new TableAntiquesImg
            {
                Id = Guid.NewGuid().GetGuidStr(),
                AntiquesId = model.Id,
                ImgUrl = x.ImgUrl,
                HotLevel = x.HotLevel,
                Remark = ""
            });
            await _context.Antiques.AddAsync(model);
            await AddAntiquesImg(listImgUrl);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 添加图片信息
        /// </summary>
        /// <param name="listImg"></param>
        /// <returns></returns>
        private async Task AddAntiquesImg(IEnumerable<TableAntiquesImg> listImg)
        {
            await _context.AntiquesImg.AddRangeAsync(listImg);
        }

        /// <summary>
        /// 获得单条文物信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EntityAntiques> GetSingleAntiquesInfoAsync(string name, string maxClassId)
        {
            var result = await _context.Antiques.FirstOrDefaultAsync(x => x.Name == name && x.MaxClassId == maxClassId);
            return Mapper.Map<TableAntiques, EntityAntiques>(result);
        }

        /// <summary>
        /// 获得文物信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EntityAntiques> GetAntiquesInfoAsync(string id)
        {
            var antiques = await _context.Antiques.FirstOrDefaultAsync(x => x.Id == id);
            var result = Mapper.Map<TableAntiques, EntityAntiques>(antiques);
            result.ListImg = Mapper.Map<List<TableAntiquesImg>, List<EntityAntiquesImg>>(await _context.AntiquesImg.Where(x => x.AntiquesId == id).ToListAsync());
            return result;
        }

        /// <summary>
        /// 分页获得文物信息
        /// </summary>
        /// <param name="entityAntiquesSearch"></param>
        /// <returns></returns>
        public async Task<PageBase<EntityAntiques>> GetPageAntiquesInfoAsync(EntityAntiquesSearch entityAntiquesSearch)
        {
            var result = new PageBase<EntityAntiques>
            {
                CurrentPage = entityAntiquesSearch.CurrentPage,
                PageSize = entityAntiquesSearch.PageSize
            };
            var queryExpression = GetPageExpression(entityAntiquesSearch);
            result.TotalCounts = await _context.Antiques.CountAsync(queryExpression);
            var data = await _context.Set<TableAntiques>().Where(queryExpression).OrderByDescending(x => x.CreateTime).Skip(entityAntiquesSearch.PageSize * (entityAntiquesSearch.CurrentPage - 1)).Take(entityAntiquesSearch.PageSize).ToListAsync();
            result.Items = Mapper.Map<List<TableAntiques>, List<EntityAntiques>>(data);
            result.TotalPages = Convert.ToInt32(Math.Ceiling(result.TotalCounts / (entityAntiquesSearch.PageSize * 1.0)));
            return result;
        }



        /// <summary>
        /// 更新文物信息
        /// </summary>
        /// <param name="entityAntiques"></param>
        /// <returns></returns>
        public async Task UpdateAntiquesAsync(EntityAntiques entityAntiques)
        {
            var antiques = await _context.Antiques.FirstOrDefaultAsync(x => x.Id == entityAntiques.Id);
            antiques.Name = entityAntiques.Name;
            antiques.MaxClassId = entityAntiques.MaxClassId;
            antiques.MinClassId = entityAntiques.MinClassId ?? "";
            antiques.AgeInfo = entityAntiques.AgeInfo;
            antiques.FeatureInfo = entityAntiques.FeatureInfo;
            antiques.UnearthedInfo = entityAntiques.UnearthedInfo;
            antiques.BookInfo = entityAntiques.BookInfo;
            antiques.Description = entityAntiques.Description;
            antiques.VoiceUrl = entityAntiques.VoiceUrl ?? "";
            _context.Antiques.Update(antiques);

            //先删除在新增
            var listImg = _context.AntiquesImg.Where(x => x.AntiquesId == entityAntiques.Id);
            _context.AntiquesImg.RemoveRange(listImg);
            var listImgUrl = entityAntiques.ListImg.Select(x => new TableAntiquesImg
            {
                Id = Guid.NewGuid().GetGuidStr(),
                AntiquesId = entityAntiques.Id,
                ImgUrl = x.ImgUrl,
                HotLevel = x.HotLevel,
                Remark = ""
            });
            await AddAntiquesImg(listImgUrl);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 获得搜索表达式树
        /// </summary>
        /// <param name="entityAntiquesSearch"></param>
        /// <returns></returns>
        private Expression<Func<TableAntiques, bool>> GetPageExpression(EntityAntiquesSearch entityAntiquesSearch)
        {
            Expression<Func<TableAntiques, bool>> pageExpression = x => x.IsEnable == true;

            if (!string.IsNullOrEmpty(entityAntiquesSearch.Name))
            {
                Expression<Func<TableAntiques, bool>> nameExpression = x => x.Name.Contains(entityAntiquesSearch.Name);
                pageExpression = pageExpression.And(nameExpression);
            }
            if (!string.IsNullOrEmpty(entityAntiquesSearch.MaxClassId))
            {
                Expression<Func<TableAntiques, bool>> maxClassExpression = x => x.MaxClassId == entityAntiquesSearch.MaxClassId;
                pageExpression = pageExpression.And(maxClassExpression);
            }
            if (!string.IsNullOrEmpty(entityAntiquesSearch.MinClassId))
            {
                Expression<Func<TableAntiques, bool>> minClassExpression = x => x.MinClassId == entityAntiquesSearch.MinClassId;
                pageExpression = pageExpression.And(minClassExpression);
            }
            return pageExpression;
        }
    }
}
