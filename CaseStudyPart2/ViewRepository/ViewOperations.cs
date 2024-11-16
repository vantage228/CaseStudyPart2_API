using CaseStudyPart2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyPart2.ViewRepository
{
    public class ViewOperations : IView
    {
        ApplicationDBContext _dbContext;
        public ViewOperations(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<View> GetData(int pageNumber, int pageSize, DateTime? asOfDate = null)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                throw new ArgumentException("Page number and page size must be greater than 0.");
            }

            IQueryable<View> query = _dbContext.vuMergeData;

            // Apply date filter if provided
            if (asOfDate.HasValue)
            {
                query = query.Where(v => v.AsOfDate.HasValue &&
                                         v.AsOfDate.Value == DateOnly.FromDateTime(asOfDate.Value));
            }

            // Apply pagination
            return query
                .Skip((pageNumber - 1) * pageSize) // Skip records for previous pages
                .Take(pageSize)                   // Take only the records for the current page
                .ToList();
        }

        public BigInteger GetTotalRecords(DateTime? asOfDate = null)
        {
            IQueryable<View> query = _dbContext.vuMergeData;

            // Apply date filter if provided
            if (asOfDate.HasValue)
            {
                query = query.Where(v => v.AsOfDate.HasValue &&
                                         v.AsOfDate.Value == DateOnly.FromDateTime(asOfDate.Value));
            }

            return query.Count();
        }


    }
}
