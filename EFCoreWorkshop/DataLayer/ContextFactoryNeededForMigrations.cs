using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


namespace DataLayer
{
    public class ContextFactoryNeededForMigrations : IDesignTimeDbContextFactory<AppDataContext>
    {
        //private const string ConnectionString =
        //    "Server=(localdb)\\mssqllocaldb;Database=EfCoreInActionDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        public AppDataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<AppDataContext>();
            optionsBuilder.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("DataLayer"));

            return new AppDataContext(optionsBuilder.Options);
        }
    }
}
