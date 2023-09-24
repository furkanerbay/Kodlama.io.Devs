using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramingLanguage>(p =>
            {
                p.ToTable("ProgramingLanguages").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
            });

            ProgramingLanguage[] programingLanguageSeeds = { new(1, "C"), new(2, "C++") };
            modelBuilder.Entity<ProgramingLanguage>().HasData(programingLanguageSeeds);

            modelBuilder.Entity<Technology>(t =>
            {
                t.ToTable("Technologies").HasKey(t => t.Id);
                t.Property(t => t.Id).HasColumnName("Id");
                t.Property(t => t.Name).HasColumnName("Name");
            });

            Technology[] technologySeeds = { new(1,4,"Spring"), new(2,3,"ASP.NET") };
            modelBuilder.Entity<Technology>().HasData(technologySeeds);
        }
    }
}
