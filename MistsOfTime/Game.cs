using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MistsOfTime.Assets;
using MistsOfTime.Interface;
using MistsOfTime.Universe;

namespace MistsOfTime
{
    internal class Game
    {
        internal Game()
        {
            World = new World(20, 20);
            Here = World.GetStartingLocation();
            
            ActiveScreen = new IntroScreen(this);
            ActiveScreen.ChangeActiveScreen += OnActiveScreenChanged;
        }

        public World World { get; set; }
        public Location Here { get; set; }
        internal IScreen ActiveScreen { get; set; }
        public bool IsGameOn { get; set; }

        public void Play()
        {
            IsGameOn = true;

            while(IsGameOn)
            {
                Console.Clear();

                ActiveScreen.Display();

                var input = Console.ReadKey();
                ActiveScreen.HandleInput(input);

                if (input.Key == ConsoleKey.Escape)
                    IsGameOn = false;
            }
        }

        #region Helper Methods
        private void OnActiveScreenChanged(object sender, ScreenEventArgs e)
        {
            ActiveScreen.ChangeActiveScreen -= OnActiveScreenChanged;
            ActiveScreen = e.Screen;
            ActiveScreen.ChangeActiveScreen += OnActiveScreenChanged;
        }
        #endregion
    }
}
