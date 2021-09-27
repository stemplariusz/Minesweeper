namespace Minesweeper.Model
{
    class GameBoard
    {
        private int Height { get; set; }
        private int Width { get; set; }


        public GameBoard(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
