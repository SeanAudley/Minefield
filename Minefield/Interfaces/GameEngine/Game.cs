using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minefield.Interfaces.RandomNumberGen;
using Minefield.Interfaces.UserInterface;
using Minefield.Interfaces.Player;
using Minefield.Interfaces;

namespace Minefield.Interfaces.Game
{


    public class Game : IGame
    {

        private readonly int _gridSize = 8;
        private readonly Helpers.Convert _helper;
        private readonly IRandomProvider _randomProvider;
        private readonly IUserInterface _userInterface;
        private IPlayer _player;
        private Minefield _minefield;
        private int _playerRow;
        private int _playerCol;
        private int _moves;

        public Game(IRandomProvider randomProvider, IUserInterface userInterface, IPlayer player)
        {
            _randomProvider = randomProvider;
            _player = player;
            _userInterface = userInterface;

            _helper = new Helpers.Convert();
        }


        public void Play()
        {
            InitializeGame();

            while (true)
            {
                DisplayGameState();

                string input = GetUserInput();
                MovePlayer(input);

                if (CheckForMine())
                {
                    _userInterface.DisplayMessage("Boom! You hit a mine!");
                    DecrementLives();
                    if (_player.LivesLeft() <= 0)//if (_lives <= 0)
                    {
                        _userInterface.DisplayMessage("Game over! You ran out of lives.");
                        break;
                    }
                }

                IncrementMoves();

                if (PlayerReachedEnd())
                {
                    _userInterface.DisplayMessage("Congratulations! You reached the other side of the board!");
                    break;
                }

            }

            _userInterface.DisplayMessage("Thank you for playing!");
        }
        public bool PlayerHitMine(int playerRow, int playerCol)
        {
            return _minefield.CheckForMineHit(playerRow, playerCol);
        }

        private void InitializeGame()
        {

            Console.WriteLine("Welcome to the Minefield Chessboard Game!");

            // set players position and state
            _playerRow = 0;
            _playerCol = 0;
            _moves = 0;

            _minefield = new Minefield(_randomProvider, _gridSize, 8);
            _minefield.GenerateMinefield();

        }

        private void DisplayGameState()
        {

            _userInterface.DisplayMessage($"Current position: {_helper.ConvertToChessNotation(_playerRow, _playerCol, _gridSize)}, Lives: {_player.LivesLeft()}, Moves: {_moves}");
        }

        private bool PlayerReachedEnd()
        {
            //has the player traversed from up to down or left to right? 
            return _playerCol == _gridSize - 1 || _playerRow == _gridSize - 1;
        }

        private string GetUserInput()
        {
            _userInterface.DisplayMessage("Enter move direction (up, down, left, right):");
            return _userInterface.GetUserInput();
        }

        private void MovePlayer(string direction)
        {
            switch (direction)
            {
                case "up":
                    if (_playerRow > 0)
                        _playerRow--;
                    break;
                case "down":
                    if (_playerRow < _gridSize - 1)
                        _playerRow++;
                    break;
                case "left":
                    if (_playerCol > 0)
                        _playerCol--;
                    break;
                case "right":
                    _playerCol++;
                    break;
                default:
                    Console.WriteLine("Invalid input! Please enter either up, down, left, or right.");
                    break;
            }
        }

        private bool CheckForMine()
        {
            return _minefield.CheckForMineHit(_playerRow, _playerCol);
        }


        private void DecrementLives()
        {
            _player.DeductLife();
            _moves++;
        }

        private void IncrementMoves()
        {
            _moves++;
        }


    }


}
