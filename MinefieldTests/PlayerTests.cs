using Microsoft.VisualStudio.TestPlatform.Utilities;
using Minefield.Interfaces;
using Minefield.Interfaces.Player;
using static Microsoft.VisualStudio.TestPlatform.Utilities.ConsoleOutput;


namespace MinefieldTests
{


    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void TestPlayer_DecrementLives()
        {
        
            // Creating game instance
            IPlayer player = new Player(3);
            player.DeductLife();

            Assert.IsTrue(player.LivesLeft() == 2); // After hitting a mine, lives should decrement
        }

     
    }


}