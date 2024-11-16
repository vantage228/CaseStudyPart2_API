using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyPart2.Models
{
    public class Constituents
    {
        [Name("Symbol")]
        public string Symbol { get; set; }
        [Name("Security")]
        public string Security { get; set; }
        [Name("GICS�Sector")]
        public string GICS_Sector {get; set;}
        [Name("GICS Sub-Industry")]
        public string GICS_Sub_Industry { get; set;}
        [Name("Headquarters Location")]
        public string Headquarters_Location { get; set;}
        [Name("Date first added")]
        public string Date_First_Added { get; set;}
        [Name("CIK")]
        public string CIK {  get; set;}
        [Name("Founded")]
        public string Founded {  get; set;}
    }
}
