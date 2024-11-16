using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyPart2.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = 192.168.0.13\\sqlexpress,49753; Initial Catalog = IVP_O_S_CS; user Id = sa; Password = sa@12345678; TrustServerCertificate = True");
        }
        public DbSet<View> vuMergeData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<View>()
                .ToView("vuMergeData")  
                .HasNoKey();             

            base.OnModelCreating(modelBuilder);
        }
    }
}
