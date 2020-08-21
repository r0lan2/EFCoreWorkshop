using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Status
    {
        public int StatusId { get; set; }
        
        public bool IsOk { get; set; }

        public string Description { get; set; }

        public Inspection Inspection { get; set; }

        public int InspectionId { get; set; }


    }
}
