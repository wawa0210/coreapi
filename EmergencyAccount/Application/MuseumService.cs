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
    public class MuseumService : IMuseumService
    {
        private readonly EfDbContext _context;
        public MuseumService(EfDbContext context)
        {
            _context = context;
        }
        public async Task AddMuseumAsync(EntityMuseum entityMuseum)
        {
            var model = new TableMuseum
            {
                Id = Guid.NewGuid().GetGuidStr(),
                Name = entityMuseum.Name
            };
            await _context.Museums.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DisableMuseumAsync(string id)
        {
            var model = await _context.Museums.FirstAsync(x => x.Id == id);
            model.IsEnable =false;
            await _context.SaveChangesAsync();
        }

        public async Task EditMuseumAsync(EntityMuseum entityMuseum)
        {
            var model = await _context.Museums.FirstAsync(x => x.Id == entityMuseum.Id);
            //model.IsEnable = entityMuseum.IsEnable;
            model.Name = entityMuseum.Name;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 分页获得博物馆信息
        /// </summary>
        /// <param name="entityMuseumSearch"></param>
        /// <returns></returns>
        public async Task<PageBase<EntityMuseum>> GetPageMuseumAsync(EntityMuseumSearch entityMuseumSearch)
        {
            var result = new PageBase<EntityMuseum>
            {
                CurrentPage = entityMuseumSearch.CurrentPage,
                PageSize = entityMuseumSearch.PageSize
            };
            var queryExpression = GetPageExpression(entityMuseumSearch);
            result.TotalCounts = await _context.Museums.CountAsync(queryExpression);
            var data = await _context.Set<TableMuseum>().Where(queryExpression).OrderByDescending(x => x.CreateTime).Skip(entityMuseumSearch.PageSize * (entityMuseumSearch.CurrentPage - 1)).Take(entityMuseumSearch.PageSize).ToListAsync();
            result.Items = Mapper.Map<List<TableMuseum>, List<EntityMuseum>>(data);
            result.TotalPages = Convert.ToInt32(Math.Ceiling(result.TotalCounts / (entityMuseumSearch.PageSize * 1.0)));
            return result;
        }

        /// <summary>
        /// 获得搜索表达式树
        /// </summary>
        /// <param name="entityAntiquesSearch"></param>
        /// <returns></returns>
        private Expression<Func<TableMuseum, bool>> GetPageExpression(EntityMuseumSearch entityMuseumSearch)
        {
            Expression<Func<TableMuseum, bool>> pageExpression = x => x.IsEnable == true;

            if (!string.IsNullOrEmpty(entityMuseumSearch.Name))
            {
                Expression<Func<TableMuseum, bool>> nameExpression = x => x.Name.Contains(entityMuseumSearch.Name);
                pageExpression = pageExpression.And(nameExpression);
            }
            return pageExpression;
        }
    }
}
