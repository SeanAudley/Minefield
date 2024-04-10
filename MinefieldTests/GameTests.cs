using Microsoft.VisualStudio.TestPlatform.Utilities;
using Minefield.Interfaces.Game;
using Minefield.Interfaces.Player;
using Minefield.Interfaces.RandomNumberGen;
using Minefield.Interfaces.UserInterface;
using MinefieldTests.Helper;


namespace MinefieldTests
{


    [TestFixture]
    public class GameTests
    {
        [Test]
        public void TestPlayer_HitMine()
        {
            // Mocking random provider
            var mockRandomProvider = new Mock<IRandomProvider>();
            mockRandomProvider.SetupSequence(x => x.Next(It.IsAny<int>(), It.IsAny<int>()))
                              .Returns(0) // Mocking mine position
                              .Returns(0) // Mocking player position
                              .Returns(0); // Mocking player position

            var mockUserInterface = new Mock<IUserInterface>();




            // Creating game instance
            IPlayer player = new Player(3);
            IGame game = new Game(mockRandomProvider.Object, mockUserInterface.Object, player);
            
            // Running game play
            game.Play();
            
            bool didWeHitMine = game.PlayerHitMine(0, 0);


            // Asserting user interface calls
            Assert.IsTrue(didWeHitMine == true); // After hitting a mine, lives should decrement

        }

        [Test]
        public void TestPlayer_ReachedEnd_GameWon()
        {
            // Mocking random provider
            var mockRandomProvider = new Mock<IRandomProvider>();
            mockRandomProvider.SetupSequence(x => x.Next(It.IsAny<int>(), It.IsAny<int>()))
                              .Returns(0) // Mocking mine position
                              .Returns(7); // Mocking player position

            // Mocking user interface
            var mockUserInterface = new Mock<IUserInterface>();
            mockUserInterface.SetupSequence(x => x.GetUserInput())
                             .Returns("right")
                             .Returns("right")
                             .Returns("right")
                             .Returns("right")
                             .Returns("right")
                             .Returns("right")
                             .Returns("right")
                             .Returns("");

            // Creating game instance
            IPlayer player = new Player(3);
            IGame game = new Game(mockRandomProvider.Object, mockUserInterface.Object, player);

            // Running game play
            game.Play();

            // Asserting user interface calls
            mockUserInterface.Verify(x => x.DisplayMessage("Congratulations! You reached the other side of the board!"), Times.Once);
        }


    }


}