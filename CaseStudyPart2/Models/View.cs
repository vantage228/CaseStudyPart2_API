using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyPart2.Models
{
    public class View
    {
        public DateOnly? AsOfDate {  get; set; }

        public string? Ticker { get; set; }

        public string? Security { get; set; }
        public string? GICS_Sector { get; set; }
        public string? GICS_Sub_Industry { get; set; }
        public string? Headquarters_Location { get; set; }
        public string? Founded { get; set; }
        public decimal? Open { get; set; }

        public decimal? Close { get; set; }

        public decimal? DTD_Change_Percent { get; set; }

        public decimal? MTD_Change_Percent { get; set; }
        public decimal? QTD_Change_Percent { get; set; }
        public decimal? YTD_Change_Percent { get; set; }

    }
}
