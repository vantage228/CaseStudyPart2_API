using CaseStudyPart2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyPart2.ViewRepository
{
    public interface IView
    {
        public BigInteger GetTotalRecords(DateTime? asOfDate = null);

        public List<View> GetData(int pageNumber, int pageSize, DateTime? asOfDate = null);
    }
}
