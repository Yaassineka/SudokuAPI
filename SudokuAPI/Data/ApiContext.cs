using SudokuAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SudokuAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Sudoku> Solutions { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            :base(options)
        {

        }
    }
}
