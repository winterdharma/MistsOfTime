using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MistsOfTime.Assets;
using MistsOfTime.Universe;

namespace MistsOfTime
{
    public class Game
    {
        private ConsoleKey[] _moveKeys = new ConsoleKey[] 
            { ConsoleKey.N, ConsoleKey.S, ConsoleKey.E, ConsoleKey.W,
              ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow,
              ConsoleKey.LeftArrow };

        public Game()
        {
            World = new World(20, 20);
            Here = World.GetStartingLocation();
            ActionResult = new List<string>();
        }

        public World World { get; set; }
        public Location Here { get; set; }
        public List<string> ActionResult { get; set; }
        public bool IsGameOn { get; set; }

        public void Play()
        {
            IsGameOn = true;

            while(IsGameOn)
            {
                Console.Clear();

                DisplayActionResult();
                DisplayLocationInfo();
                
                var input = Console.ReadKey();

                if (_moveKeys.Contains(input.Key))
                    Move(input.Key);
                
                else if (input.Key == ConsoleKey.Escape)
                    IsGameOn = false;
            }
        }

        private void DisplayLocationInfo()
        {
            if (Here.Description.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Here.Coords + " : " + Here.Name);
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (string line in Here.Description)
                {
                    Console.WriteLine(line);
                }
            }
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

        private void Move(ConsoleKey dir)
        {
            Location newPlace = Here;
            bool isValidMove = false;
            string result = "";
            switch (dir)
            {
                case ConsoleKey.N:
                case ConsoleKey.UpArrow:
                    isValidMove = World.MoveNorth(Here, out newPlace);
                    result = "You travel north.";
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    isValidMove = World.MoveSouth(Here, out newPlace);
                    result = "You travel south.";
                    break;
                case ConsoleKey.E:
                case ConsoleKey.RightArrow:
                    isValidMove = World.MoveEast(Here, out newPlace);
                    result = "You travel east.";
                    break;
                case ConsoleKey.W:
                case ConsoleKey.LeftArrow:
                    isValidMove = World.MoveWest(Here, out newPlace);
                    result = "You travel west.";
                    break;
            }
            Here = newPlace;
            if(!isValidMove)
                result = LocationStrings.MovedOutOfBounds;
            ActionResult.Add(result);
                
        }
    }
}
