using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SudokuAPI.Models;
using SudokuAPI.Data;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;

namespace SudokuAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SudokuController : ControllerBase
    {
        private readonly ApiContext _context;

        public SudokuController(ApiContext context)
        {
            _context = context;
            
        }

        [HttpPost]
        [Route("/SendResult")]
        public JsonResult CreateEdit(Sudoku solution)
        {
            if (solution.Id == 0)
            {
                _context.Solutions.Add(solution);
            }
            else
            {
                var solutionInDb = _context.Solutions.Find(solution.Id);

                if (solutionInDb == null)
                    return new JsonResult(NotFound());

                solutionInDb = solution;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(solution));
        }

        [HttpGet()]
        [Route("/GetResults")]
        public JsonResult GetAll()
        {
            var result = _context.Solutions.ToList();

            return new JsonResult(Ok(result));
        }
    }
 
}
