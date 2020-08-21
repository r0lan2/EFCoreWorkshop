using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Inspection
    {
        public int InspectionId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Description { get; set; }

        public Status Status { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<InspectionResponsible> Responsible { get; set; }

    }
}
