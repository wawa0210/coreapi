using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {

        }
        public DbSet<TableAccountManager> AccountManagerData { get; set; }
        public DbSet<TableAntiquesClass> MuseumAntiquesClass { get; set; }

        public DbSet<TableMuseum> Museums { get; set; }
        public DbSet<TableAntiques> Antiques { get; set; }
        public DbSet<TableAntiquesImg> AntiquesImg { get; set; }
    }
}
