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
            ActionResult = string.Empty;
        }

        public World World { get; set; }
        public Location Here { get; set; }
        public string ActionResult { get; set; }
        public bool IsGameOn { get; set; }

        public void Play()
        {
            IsGameOn = true;

            while(IsGameOn)
            {
                Console.Clear();

                if (ActionResult.Length > 0)
                {
                    Console.WriteLine(ActionResult);
                    ActionResult = string.Empty;
                }

                Console.WriteLine(Here.Coords + " : " + Here.Description);

                var input = Console.ReadKey();

                if (_moveKeys.Contains(input.Key))
                    Move(input.Key);
                
                else if (input.Key == ConsoleKey.Escape)
                    IsGameOn = false;
            }
        }

        private void Move(ConsoleKey dir)
        {
            Location newPlace = Here;
            bool isValidMove = false;
            switch(dir)
            {
                case ConsoleKey.N:
                case ConsoleKey.UpArrow:
                    isValidMove = World.MoveNorth(Here, out newPlace);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    isValidMove = World.MoveSouth(Here, out newPlace);
                    break;
                case ConsoleKey.E:
                case ConsoleKey.RightArrow:
                    isValidMove = World.MoveEast(Here, out newPlace);
                    break;
                case ConsoleKey.W:
                case ConsoleKey.LeftArrow:
                    isValidMove = World.MoveWest(Here, out newPlace);
                    break;
            }
            Here = newPlace;
            if(!isValidMove)
                ActionResult = LocationStrings.MovedOutOfBounds;
        }
    }
}
