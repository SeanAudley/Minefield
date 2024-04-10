using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Interfaces.Player
{
    public interface IPlayer
    {
        public int LivesLeft();

        public void DeductLife();
    }
}
