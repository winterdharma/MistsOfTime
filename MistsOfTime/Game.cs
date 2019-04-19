using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool IsGameOn { get; set; }

        public void Play()
        {
            IsGameOn = true;

            while(IsGameOn)
            {
                Console.ReadKey();
                IsGameOn = false;
            }
        }
    }
}
