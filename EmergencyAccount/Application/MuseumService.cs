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

        public async Task EditMuseumAsync(EntityMuseum entityMuseum)
        {
            var model = await _context.Museums.FirstAsync(x => x.Id == entityMuseum.Id);
            model.IsEnable = entityMuseum.IsEnable;
            model.Name = entityMuseum.Name;
            _context.Museums.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EntityMuseum>> GetAllMuseumAsync()
        {
            var result = await _context.Museums.ToListAsync();
            return Mapper.Map<List<TableMuseum>, List<EntityMuseum>>(result.FindAll(x => x.IsEnable));
        }
    }
}
