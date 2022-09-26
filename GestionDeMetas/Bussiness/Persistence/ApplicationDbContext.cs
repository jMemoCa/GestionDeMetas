using GestionDeMetas.Bussiness.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Bussiness.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {


        }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meta>().HasKey(x=>x.Id);
            modelBuilder.Entity<Meta>().HasIndex(x => x.Nombre).IsUnique();

            modelBuilder.Entity<Actividad>().HasKey(x => x.Id);
            modelBuilder.Entity<Actividad>().HasIndex(x => x.Nombre).IsUnique();
            modelBuilder.Entity<Actividad>().HasOne(x => x.Meta).WithMany(d=>d.Actividades).HasForeignKey(x=>x.MetaId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Meta> Meta { get; set; }
        public DbSet<Actividad> Actividad { get; set; }

    }


}
