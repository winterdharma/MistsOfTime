using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistsOfTime.Interface
{
    internal interface IScreen
    {
        event EventHandler<ScreenEventArgs> ChangeActiveScreen;
        void Display();
        void HandleInput(ConsoleKeyInfo key);

        Game Game { get; set; }
    }
}
