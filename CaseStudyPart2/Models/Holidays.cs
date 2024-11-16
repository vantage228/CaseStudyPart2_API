using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyPart2.Models
{
    public class Holidays
    {
        [Name("Holiday")]
        public string HolidayDate { get; set; }
        [Name("HolidayDescription")]
        public string HolidayDescription { get; set; }
    }
}
