using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.Entities;

namespace Tests.Helpers
{
    public static class EfTestData
    {

        public static void SeedDatabase(this AppDataContext context)
        {
            context.Inspections.AddRange(CreateFourInspections());
            context.SaveChanges();
        }

        public static List<Inspection> CreateFourInspections()
        {
            var company = new Company() {Name = "Company 1"};
            var responsible1 = new Responsible(){ Name = "Rolando Martinez" };
            var inspections = new List<Inspection>();
            var inspection1 = new Inspection
            {
                Company = company,
                Description = "Inspection 1",
                Reviews = new List<Review>()
                {
                    new Review() {Comment = "answer 1", Question = "question 1", Score = 1}
                }
            };
            inspection1.Responsible = new List<InspectionResponsible>() { new InspectionResponsible() { Responsible  = responsible1,Inspection = inspection1, SecurityCode = "code 1"} };
            inspections.Add(inspection1);
            return inspections;
        }


    }
}
