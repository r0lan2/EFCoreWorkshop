using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace ServiceLayer.Dto
{
    public class InspectionDto
    {
        public int CompanyId { get; set; }
        public string Description { get; set; }

        public List<ReviewDto> Reviews { get; set; }
        public List<Responsible> Responsible { get; set; }

    }
}
