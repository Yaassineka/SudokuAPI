using System.Text.Json;

namespace SudokuAPI.Models
{
    public class Sudoku
    {
        public int Id { get; set; }
        public JsonElement Solution { get; set; }

    }
}
