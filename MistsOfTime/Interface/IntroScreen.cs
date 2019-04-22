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
            ScreenText = SetScreenText();
        }

        public Game Game { get; set; }
        public List<TextObject> ScreenText { get; set; }

        public void Display()
        {
            Display(ScreenText);
        }

        public void Display(List<TextObject> textElement)
        {
            foreach(TextObject line in textElement)
            {
                line.WriteLine();
            }
        }

        public void HandleInput(ConsoleKeyInfo key)
        {
            ChangeActiveScreen?.Invoke(this, new ScreenEventArgs(new LocationScreen(Game)));
        }


        private List<TextObject> SetScreenText()
        {
            var screenText = new List<TextObject>();
            var fgColor = ConsoleColor.Gray;
            var bgColor = ConsoleColor.Black;
            foreach (string line in GameTexts.IntroText)
            {
                string printLine = line;
                SetColors(line, out printLine, out fgColor, out bgColor);
                screenText.Add(new TextObject(printLine, fgColor, bgColor));
            }
            return screenText;
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
