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
        public Game()
        {
            World = new World(20, 20);
            Here = World.GetStartingLocation();
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

                Console.WriteLine(ActionResult);
                ActionResult = string.Empty;

                Console.WriteLine(Here.Coords + " : " + Here.Description);

                var input = Console.ReadKey();

                Location newPlace = null;
                if (input.Key == ConsoleKey.N)
                {
                    if (World.MoveNorth(Here, out newPlace))
                        Here = newPlace;
                    else
                        ActionResult = LocationStrings.MovedOutOfBounds;
                }
                else if(input.Key == ConsoleKey.E)
                {
                    if (World.MoveEast(Here, out newPlace))
                        Here = newPlace;
                    else
                        ActionResult = LocationStrings.MovedOutOfBounds;
                }
                else if(input.Key == ConsoleKey.S)
                {
                    if (World.MoveSouth(Here, out newPlace))
                        Here = newPlace;
                    else
                        ActionResult = LocationStrings.MovedOutOfBounds;
                }
                else if(input.Key == ConsoleKey.W)
                {
                    if (World.MoveWest(Here, out newPlace))
                        Here = newPlace;
                    else
                        ActionResult = LocationStrings.MovedOutOfBounds;
                }
                else if (input.Key == ConsoleKey.Escape)
                    IsGameOn = false;
            }
        }
    }
}
