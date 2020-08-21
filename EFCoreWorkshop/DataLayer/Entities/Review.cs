using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Score { get; set; }
        public string Question { get; set; }
        public string Comment { get; set; }

        public Inspection Inspection { get; set; }
        public int InspectionId { get; set; }

    }
}
