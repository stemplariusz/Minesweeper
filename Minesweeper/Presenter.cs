namespace Minesweeper
{
    using Model;
    class Presenter
    {
        IView _view;
        GameEngine _game;

        public Presenter(IView view, GameEngine gameEngine)
        {
            _view = view;
            _view.Shoting += _view_Shoting;
            _game = gameEngine;
            _game.StateIsUpdated += _game_Updated;
            _game.EndGame += _game_EndGame;
            gameEngine.LoadMineField();
            gameEngine.SaveMineField();
        }

        private void _game_EndGame()
        {
            _view.Win();
        }

        private void _game_Updated(int x, int y, string character)
        {
            _view.DisplaySquare(x, y, character);
        }

        private void _view_Shoting(int x, int y)
        {
            _game.Player.Shot(x, y);
        }
    }
}
