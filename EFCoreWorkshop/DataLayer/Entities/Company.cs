using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public ICollection<Inspection> Inspections { get; set; }

    }
}
