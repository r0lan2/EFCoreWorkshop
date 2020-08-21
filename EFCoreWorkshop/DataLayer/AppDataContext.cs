using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDataContext : DbContext
    {
        public DbSet<Inspection> Inspections { get; set; }            
        public DbSet<Company> Companies { get; set; }        
        public DbSet<InspectionResponsible> InspectionResponsible { get; set; }
        public DbSet<Responsible> Responsible { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Status> Status { get; set; }



        public AppDataContext(                            
            DbContextOptions<AppDataContext> options)     
            : base(options) { }                            

        protected override void
            OnModelCreating(ModelBuilder modelBuilder)    
        {                                                
            modelBuilder.Entity<InspectionResponsible>()             
                .HasKey(x => new { x.InspectionId, x.ResponsibleId });
            
            modelBuilder.Entity<Inspection>()
                .HasOne(i => i.Status)
                .WithOne(s => s.Inspection)
                .HasForeignKey<Status>(b => b.InspectionId);
        }


    }
}
