using System;

namespace MistsOfTime.Assets
{
    internal class TextObject
    {
        internal TextObject(string text, ConsoleColor fgColor, ConsoleColor bgColor)
        {
            Text = text;
            TextColor = fgColor;
            BackgroundColor = bgColor;
        }

        internal string Text { get; set; }
        internal ConsoleColor TextColor { get; set; }
        internal ConsoleColor BackgroundColor { get; set; }

        internal void WriteLine()
        {
            Console.ForegroundColor = TextColor;
            Console.BackgroundColor = BackgroundColor;
            Console.WriteLine(Text);
        }

        internal void WriteTextSegment()
        {
            Console.ForegroundColor = TextColor;
            Console.BackgroundColor = BackgroundColor;
            Console.Write(Text);
        }
    }
}
