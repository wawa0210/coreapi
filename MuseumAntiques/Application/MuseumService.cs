using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using MuseumAntiques.Entity;
using Microsoft.EntityFrameworkCore;

namespace MuseumAntiques.Application
{
    public class MuseumService : IMuseumService
    {
        private readonly EfDbContext _context;
        public MuseumService(EfDbContext context)
        {
            _context = context;
        }
        public Task AddMuseumAsync(EntityMuseum entityMuseum)
        {
            throw new NotImplementedException();
        }

        public Task EditMuseumAsync(EntityMuseum entityMuseum)
        {
            throw new NotImplementedException();
        }

        public Task<List<EntityMuseum>> GetAllMuseumAsync()
        {
            throw new NotImplementedException();
        }
    }
}
