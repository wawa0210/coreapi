using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CommonLib;
using DataAccess;
using EmergencyAccount.Etity;
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
                ParentId = entityAntiquesClass.ParentId,
                Remark = entityAntiquesClass.Remark,
                HotLevel = entityAntiquesClass.HotLevel,
                CreateTime = DateTime.Now,
            };
            await _context.MuseumAntiquesClass.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task<EntityAntiquesClass> GetAntiquesClassAsync(string id)
        {
            var result = await _context.MuseumAntiquesClass.FirstOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<TableAntiquesClass, EntityAntiquesClass>(result);
        }

        public async Task<List<EntityAntiquesClass>> GetListAntiquesClassAsync()
        {
            var result = await _context.MuseumAntiquesClass.ToListAsync();

            return Mapper.Map<List<TableAntiquesClass>, List<EntityAntiquesClass>>(result);

        }

        public async Task UpdateAntiquesClassAsync(EntityAntiquesClass entityAntiquesClass)
        {
            var model = await _context.MuseumAntiquesClass.FirstAsync(x => x.Id == entityAntiquesClass.Id);
            model.IsEnable = entityAntiquesClass.IsEnable;
            model.Title = entityAntiquesClass.Title;
            model.Description = entityAntiquesClass.Description;
            model.ParentId = entityAntiquesClass.ParentId;
            model.Remark = entityAntiquesClass.Remark;
            _context.MuseumAntiquesClass.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
