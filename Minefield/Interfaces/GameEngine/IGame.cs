using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Interfaces.Game
{
    public interface IGame
    {
        void Play();
        bool PlayerHitMine(int playerRow, int playerCol);
    }

}
