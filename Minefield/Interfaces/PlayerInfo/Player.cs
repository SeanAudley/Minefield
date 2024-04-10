using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Interfaces.Player
{
    public class Player : IPlayer
    {

        private int _livesLeft { get; set; }

        private int _maxLives;


        public Player(int totalLives)
        {
            _maxLives = totalLives;
            _livesLeft = _maxLives;
        }

        int IPlayer.LivesLeft()
        {
            return _livesLeft;
        }

        void IPlayer.DeductLife()
        {
            _livesLeft--;
        }
    }
}
