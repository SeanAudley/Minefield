using Minefield.Interfaces;
using Minefield.Interfaces.Game;
using Minefield.Interfaces.Player;
using Minefield.Interfaces.RandomNumberGen;
using Minefield.Interfaces.UserInterface;

IRandomProvider randomProvider = new RandomProvider();

IPlayer player = new Player(3);   //instantiate a player with 3 lives
IUserInterface userInterface= new UserInterface();


//inject game with random number gen, userinterface, and player
IGame game = new Game(randomProvider, userInterface, player);
    
// execute the game
game.Play();

