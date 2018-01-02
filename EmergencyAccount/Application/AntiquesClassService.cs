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
using EmergencyAccount.Enum;
using EmergencyAccount.Etity;
using EmergencyAccount.Etity.Dto;
using Microsoft.EntityFrameworkCore;

namespace EmergencyAccount.Application
{
    public class AntiquesClassService : IAntiquesClassService
    {
        private readonly EfDbContext _context;
        public AntiquesClassService(EfDbContext context)
        {
            _context = context;
        }

        public async Task AddAntiquesClassAsync(EntityAntiquesClass entityAntiquesClass)
        {
            var model = new TableAntiquesClass
            {
                Id = Guid.NewGuid().GetGuidStr(),
                Title = entityAntiquesClass.Title,
                IsEnable = entityAntiquesClass.IsEnable,
                Description = entityAntiquesClass.Description,
                ParentId = string.IsNullOrEmpty(entityAntiquesClass.ParentId) ? "0" : entityAntiquesClass.ParentId,
                Remark = entityAntiquesClass.Remark,
                HotLevel = entityAntiquesClass.HotLevel,
                CreateTime = DateTime.Now,
            };
            await _context.MuseumAntiquesClass.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 禁用分类
        /// </summary>
        /// <param name="entityAntiquesClass"></param>
        /// <returns></returns>
        public async Task DisAbleClassAsync(string id)
        {
            var classInfo = await _context.MuseumAntiquesClass.FirstOrDefaultAsync(x => x.Id == id);
            var classLevel = classInfo.ParentId == "0" ? 1 : 2;
            var listClass = new List<TableAntiquesClass>();
            var listAntiques = new List<TableAntiques>();
            if (classLevel == (int)EnumAntiquesClassLevel.MainLevel)
            {
                listClass = await _context.MuseumAntiquesClass.Where(x => x.Id == id || x.ParentId == id).ToListAsync();
                listAntiques = await _context.Antiques.Where(x => x.MaxClassId == id).ToListAsync();
            }
            else
            {
                listAntiques = await _context.Antiques.Where(x => x.MinClassId == id).ToListAsync();
                listClass.Add(classInfo);
            }
            listClass.ForEach(x => { x.IsEnable = false; x.Remark = "手动删除"; });
            listAntiques.ForEach(x => { x.IsEnable = false; x.Remark = "手动删除"; });

            _context.MuseumAntiquesClass.UpdateRange(listClass);
            _context.Antiques.UpdateRange(listAntiques);

            await _context.SaveChangesAsync();
        }

        public async Task<EntityAntiquesClass> GetAntiquesClassAsync(string id)
        {
            var result = await _context.MuseumAntiquesClass.FirstOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<TableAntiquesClass, EntityAntiquesClass>(result);
        }

        public async Task<PageBase<EntityAntiquesClass>> GetPageAntiquesClassAsync(EntityAntiquesClassSearch entityAntiquesClassSearch)
        {
            var result = new PageBase<EntityAntiquesClass>
            {
                CurrentPage = entityAntiquesClassSearch.CurrentPage,
                PageSize = entityAntiquesClassSearch.PageSize
            };
            var queryExpression = GetPageExpression(entityAntiquesClassSearch);
            result.TotalCounts = await _context.MuseumAntiquesClass.CountAsync(queryExpression);
            var data = await _context.Set<TableAntiquesClass>().Where(queryExpression).OrderByDescending(x => x.CreateTime).Skip(entityAntiquesClassSearch.PageSize * (entityAntiquesClassSearch.CurrentPage - 1)).Take(entityAntiquesClassSearch.PageSize).ToListAsync();
            result.Items = Mapper.Map<List<TableAntiquesClass>, List<EntityAntiquesClass>>(data);
            result.TotalPages = Convert.ToInt32(Math.Ceiling(result.TotalCounts / (entityAntiquesClassSearch.PageSize * 1.0)));
            return result;

        }

        public async Task UpdateAntiquesClassAsync(EntityAntiquesClass entityAntiquesClass)
        {
            var model = await _context.MuseumAntiquesClass.FirstAsync(x => x.Id == entityAntiquesClass.Id);
            model.IsEnable = entityAntiquesClass.IsEnable;
            model.Title = entityAntiquesClass.Title;
            model.Description = entityAntiquesClass.Description;
            model.ParentId = string.IsNullOrEmpty(entityAntiquesClass.ParentId) ? "0" : entityAntiquesClass.ParentId;
            model.Remark = entityAntiquesClass.Remark;
            _context.MuseumAntiquesClass.Update(model);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 获得搜索表达式树
        /// </summary>
        /// <param name="entityAntiquesSearch"></param>
        /// <returns></returns>
        private Expression<Func<TableAntiquesClass, bool>> GetPageExpression(EntityAntiquesClassSearch entityAntiquesClassSearch)
        {
            Expression<Func<TableAntiquesClass, bool>> pageExpression = x => x.IsEnable == true;

            if (!string.IsNullOrEmpty(entityAntiquesClassSearch.Name))
            {
                Expression<Func<TableAntiquesClass, bool>> nameExpression = x => x.Title.Contains(entityAntiquesClassSearch.Name);
                pageExpression = pageExpression.And(nameExpression);
            }
            Expression<Func<TableAntiquesClass, bool>> realExpression = x => x.ParentId == (string.IsNullOrEmpty(entityAntiquesClassSearch.ParentId) ? "0" : entityAntiquesClassSearch.ParentId);
            pageExpression = pageExpression.And(realExpression);
            return pageExpression;
        }
    }
}
