using System;

namespace Minesweeper.Model
{
    public class Player
    {
        public event Action<int, int> Shoot;
        private int[] Position { get; set; } = new[] { 0, 0 };
        private string Nick { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }

        public Player(string nick, string firstName, string lastName)
        {
            Nick = nick;
            FirstName = firstName;
            LastName = lastName;
        }


        public void Shot(int x, int y)
        {
            Position[0] = x;
            Position[1] = y;
            Shoot?.Invoke(x, y);
        }
    }
}
