using MistsOfTime.Assets;
using System;
using System.Collections.Generic;

namespace MistsOfTime.Interface
{
    internal class IntroScreen : IScreen
    {
        public event EventHandler<ScreenEventArgs> ChangeActiveScreen;

        public IntroScreen(Game game)
        {
            Game = game;
        }

        public Game Game { get; set; }

        public void Display()
        {
            DisplayMessage(GameTexts.IntroText);
        }

        public void HandleInput(ConsoleKeyInfo key)
        {
            ChangeActiveScreen?.Invoke(this, new ScreenEventArgs(new LocationScreen(Game)));
        }


        private void DisplayMessage(List<string> message)
        {
            var fgColor = ConsoleColor.Gray;
            var bgColor = ConsoleColor.Black;
            foreach (string line in message)
            {
                string printLine = line;
                SetColors(line, out printLine, out fgColor, out bgColor);
                Console.ForegroundColor = fgColor;
                Console.WriteLine(printLine);
            }
        }

        private void SetColors(string line, out string parsedLine, out ConsoleColor fgColor, out ConsoleColor bgColor)
        {
            parsedLine = line;
            fgColor = ConsoleColor.Gray;
            bgColor = ConsoleColor.Black;

            var split = line.Split('^');
            if (split.Length > 1)
            {
                fgColor = ParseColor(split[0]);
                parsedLine = split[1];
            }
        }

        private ConsoleColor ParseColor(string colorText)
        {
            colorText = colorText.ToLower();
            switch (colorText)
            {
                case "white": return ConsoleColor.White;
                case "yellow": return ConsoleColor.Yellow;
                case "gray": return ConsoleColor.Gray;
            }
            return ConsoleColor.Gray;
        }
    }
}
