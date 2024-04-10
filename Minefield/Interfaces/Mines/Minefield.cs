using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minefield.Interfaces.RandomNumberGen;
using Minefield.Interfaces;

namespace Minefield.Interfaces
{
    public class Minefield : IMinefield
    {
        private readonly int _gridSize;

        private readonly IRandomProvider _randomProvider;

        private readonly Mine[] _mines;


        public Minefield(IRandomProvider randomProvider, int gridSize, int mineCount)
        {
            _randomProvider = randomProvider;

            _gridSize = gridSize;

            _mines = new Mine[mineCount];

        }

        public void GenerateMinefield()
        {
            {
                for (int i = 0; i < _gridSize; i++)
                {
                    _mines[i] = new Mine { Row = _randomProvider.Next(0, _gridSize), Col = _randomProvider.Next(0, _gridSize) };
                }
            }

        }

        public bool CheckForMineHit(int playerRow, int playerCol)
        {

            foreach (var mine in _mines)
            {
                if (mine.Col == playerCol && mine.Row == playerRow)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
