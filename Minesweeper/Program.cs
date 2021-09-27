using System;
using System.Windows.Forms;

namespace Minesweeper
{
    static class Program
    {
        /// <summary>
        /// Minesweeper, author: Kamil Stemplewski
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IView view = new Form1();
            Model.GameEngine game = new Model.GameEngine(400, 400);
            Presenter presenter = new Presenter(view, game);

            Application.Run((Form1)view);
        }
    }
}
