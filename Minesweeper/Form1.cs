using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form, IView
    {
        Graphics canvas;
        public Form1()
        {
            InitializeComponent();
            canvas = panel1.CreateGraphics();
        }

        public event Action<int, int> Shoting;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    canvas.DrawRectangle(new Pen(Color.Blue, 1), new Rectangle(30 * i, 30 * j, 30, 30));
                }
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Shoting(e.X, e.Y);
        }

        public void DisplaySquare(int x, int y, string character)
        {
            if (character.Equals(""))
            {
                canvas.DrawImage(Bitmap.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("Minesweeper.Model.Images.0.png")), new Point(30 * x + 1, 30 * y + 1));
                //canvas.DrawImage(Image.FromFile("\\Model\\Images\\0.png"), new Point(30 * x + 1, 30 * y + 1));
            }
            else if (character.Equals("*"))
            {
                canvas.DrawImage(Bitmap.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("Minesweeper.Model.Images.bomb.png")), new Point(30 * x + 1, 30 * y + 1));
                //canvas.DrawImage(Image.FromFile("\\Model\\Images\\bomb.png"), new Point(30 * x + 1, 30 * y + 1));
                DialogResult result = MessageBox.Show("End of game!");
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            else
            {
                canvas.DrawImage(Bitmap.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("Minesweeper.Model.Images."+character+".png")), new Point(30 * x + 1, 30 * y + 1));
                //canvas.DrawImage(Image.FromFile("\\Model\\Images\\" + character + ".png"), new Point(30 * x + 1, 30 * y + 1));
            }
        }

        public void Win()
        {
            DialogResult result = MessageBox.Show("You win!");
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
