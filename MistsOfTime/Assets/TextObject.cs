using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistsOfTime.Assets
{
    internal class TextObject
    {
        internal TextObject(List<string> text, ConsoleColor fgColor, ConsoleColor bgColor)
        {

        }

        internal List<string> Text { get; set; }
        internal ConsoleColor TextColor { get; set; }
        internal ConsoleColor BackgroundColor { get; set; }

        internal void WriteText()
        {
            Console.ForegroundColor = TextColor;
            Console.BackgroundColor = BackgroundColor;
            foreach(string line in Text)
            {
                Console.WriteLine(line);
            }
        }
    }
}
