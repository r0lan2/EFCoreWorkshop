using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Tests.Helpers
{
    public static class AppSettings
    {
        public const string ConnectionStringName = "DefaultConnection";


        public static IConfigurationRoot GetConfiguration()
        {
            var testDir = Path.Combine(TestFileHelpers.GetSolutionDirectory(), "tests");
            var builder = new ConfigurationBuilder()
                .SetBasePath(testDir)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();
            return builder.Build();
        }

        /// <summary>
        /// This creates a unique database name based on the branch name and the test class name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetUniqueDatabaseConnectionString<T>(this T testClass)
        {
            var config = GetConfiguration();
            var orgConnect = config.GetConnectionString(ConnectionStringName);
            var builder = new SqlConnectionStringBuilder(orgConnect);
      
            var extraDatabaseName = $".{typeof(T).Name}";
          
            builder.InitialCatalog += extraDatabaseName;

            return builder.ToString();
        }

      
    }
}
