using System;

namespace Minesweeper
{
    interface IView
    {
        event Action<int, int> Shoting;
        void DisplaySquare(int x, int y, string character);
        void Win();
    }
}
