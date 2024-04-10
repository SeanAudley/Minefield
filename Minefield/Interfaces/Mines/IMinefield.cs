using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Interfaces
{
    public interface IMinefield
    {
        public void GenerateMinefield();
        public bool CheckForMineHit(int playerRow, int playerCol);

    }
}
