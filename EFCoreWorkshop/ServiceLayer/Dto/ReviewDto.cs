using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Dto
{
    public class ReviewDto
    {
        public int Score { get; set; }
        public string Question { get; set; }
        public string Comment { get; set; }
    }
}
