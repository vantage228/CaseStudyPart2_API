using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyPart2.Models
{
    public class Prices
    {
        [Name("Date")]
        public string Date { get; set; }
        [Name("Open")]
        public string Open {  get; set; }
        [Name("High")]
        public string High { get; set; }
        [Name("Low")]
        public string Low { get; set; }
        [Name("Close")]
        public string Close { get; set; }
        [Name("Adj Close")]
        public string AdjClose { get; set; }
        [Name("Volume")]
        public string Volume {  get; set; }
        [Name("Ticker")]
        public string Ticker { get; set; }
    }
}
