using CaseStudyPart2.ViewRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Part2_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewController : ControllerBase
    {
        IView _view;
        public ViewController(IView view)
        {
            _view = view;
        }

        [HttpGet]
        public IActionResult GetViewData([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] DateTime? asOfDate = null)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than 0.");
            }

            try
            {
                BigInteger totalRecords = _view.GetTotalRecords(asOfDate);

                int totalPages = (int)((totalRecords + pageSize - 1) / pageSize);

                var result = _view.GetData(pageNumber, pageSize, asOfDate);

                return Ok(new
                {
                    totalPages = totalPages,
                    totalRecords = (long)totalRecords, // Cast BigInteger to long
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
            }
        }
    }
}
