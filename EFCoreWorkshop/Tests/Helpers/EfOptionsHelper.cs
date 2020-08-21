using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace Tests.Helpers
{
    public static class EfOptionsHelper
    {
       /// <summary>
        /// This creates a new and seeded database every time, with a name that is unique to the class that called it
        /// </summary>
        public static DbContextOptions<AppDataContext> CreateDatabaseAndSeed4Inspections<T>(this T testClass)
        {
            var optionsBuilder = SetupOptionsWithCorrectConnection(testClass);
            EnsureDatabaseIsCreatedAndSeeded(optionsBuilder.Options, true, true);

            return optionsBuilder.Options;
        }


        //--------------------------------------------------------------------
        //private methods
        private static DbContextOptionsBuilder<AppDataContext> SetupOptionsWithCorrectConnection<T>(T testClass)
        {
            var connection = testClass.GetUniqueDatabaseConnectionString();
            var optionsBuilder =
                new DbContextOptionsBuilder<AppDataContext>();

            optionsBuilder.UseSqlServer(connection);
            return optionsBuilder;
        }

        private static void EnsureDatabaseIsCreatedAndSeeded(DbContextOptions<AppDataContext> options, bool seedDatabase, bool deleteDatabase)
        {
            using (var context = new AppDataContext(options))
            {
                if (deleteDatabase)
                    context.Database.EnsureDeleted();

                if (context.Database.EnsureCreated() && seedDatabase)
                    context.SeedDatabase();
            }
        }
    }
}
