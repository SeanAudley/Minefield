using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Helpers
{
    public class Convert
    {
        public string ConvertToChessNotation(int row, int col, int gridSize)
        {
            char chessCol = (char)('A' + col);
            return $"{chessCol}{gridSize - row}";
        }
    }
}
