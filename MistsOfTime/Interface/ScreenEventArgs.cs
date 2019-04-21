using System;

namespace MistsOfTime.Interface
{
    internal class ScreenEventArgs : EventArgs
    {
        internal IScreen Screen { get; set; }

        internal ScreenEventArgs(IScreen newScreen)
        {
            Screen = newScreen;
        }
    }
}
