using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DataLayer;
using Tests.Helpers;
using Xunit;

namespace Tests.DataLayer
{
    public class DataContextTests
    {

        [Fact]
        public void TestClientServerSimpleBookOk()
        {
            //SETUP
            var options =
                this.CreateDatabaseAndSeed4Inspections();

            using (var context = new AppDataContext(options))
            {

                var inspections = context.Inspections.ToList();
                //VERIFY
                Assert.NotNull(inspections.First());
            }
        }

    }
}
