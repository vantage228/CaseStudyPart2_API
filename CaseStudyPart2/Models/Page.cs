using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyPart2.Models
{
    class Page
    {
        public int TotalRecords { get; set; }   

        public List<View> Items { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
    }
}
