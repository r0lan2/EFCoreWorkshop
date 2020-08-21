using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class InspectionResponsible
    {
        public int ResponsibleId { get; set; }
        public int InspectionId { get; set; }

        public string SecurityCode { get; set; }

        public Responsible Responsible { get; set; }
        public Inspection Inspection { get; set; }

    }
}
