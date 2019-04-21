using MistsOfTime.Assets;
using MistsOfTime.Universe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistsOfTime.Interface
{
    internal class LocationScreen : IScreen
    {
        private ConsoleKey[] _moveKeys = new ConsoleKey[]
        {
            ConsoleKey.N, ConsoleKey.S, ConsoleKey.E, ConsoleKey.W,
            ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow,
            ConsoleKey.LeftArrow
        };

        public event EventHandler<ScreenEventArgs> ChangeActiveScreen;

        internal LocationScreen(Game game)
        {
            Game = game;
            ActionResult = new List<string>();
        }

        public List<string> ActionResult { get; set; }
        public Game Game { get; set; }

        public void Display()
        {
            DisplayTitle();

            DisplayActionResult();

            DisplayLocationInfo();
        }

        public void HandleInput(ConsoleKeyInfo keyInfo)
        {
            if (_moveKeys.Contains(keyInfo.Key))
                Move(keyInfo.Key);
        }

        private void DisplayTitle()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*******************************[ MISTS OF TIME ]*******************************");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void DisplayActionResult()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (ActionResult.Count > 0)
            {
                foreach (string line in ActionResult)
                {
                    Console.WriteLine(line);
                }
                ActionResult.Clear();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void DisplayLocationInfo()
        {
            if (Game.Here.Description.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Game.Here.Coords + " : " + Game.Here.Name);
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (string line in Game.Here.Description)
                {
                    Console.WriteLine(line);
                }
            }
        }

        private void Move(ConsoleKey dir)
        {
            Location newPlace = Game.Here;
            bool isValidMove = false;
            string result = "";
            switch (dir)
            {
                case ConsoleKey.N:
                case ConsoleKey.UpArrow:
                    isValidMove = Game.World.MoveNorth(Game.Here, out newPlace);
                    result = "You travel north.";
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    isValidMove = Game.World.MoveSouth(Game.Here, out newPlace);
                    result = "You travel south.";
                    break;
                case ConsoleKey.E:
                case ConsoleKey.RightArrow:
                    isValidMove = Game.World.MoveEast(Game.Here, out newPlace);
                    result = "You travel east.";
                    break;
                case ConsoleKey.W:
                case ConsoleKey.LeftArrow:
                    isValidMove = Game.World.MoveWest(Game.Here, out newPlace);
                    result = "You travel west.";
                    break;
            }
            Game.Here = newPlace;
            if (!isValidMove)
                result = LocationStrings.MovedOutOfBounds;
            ActionResult.Add(result);
        }
    }
}
