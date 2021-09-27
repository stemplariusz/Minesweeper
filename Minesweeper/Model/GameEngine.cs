using System;
using System.IO;

namespace Minesweeper.Model
{
    class GameEngine
    {
        public event Action<int, int, string> StateIsUpdated;
        public event Action EndGame;
        private string[,] mineField = new string[9, 9];
        private int nrFields = 0;
        private string character;
        public Player Player { get; set; }
        GameBoard gameBoard;

        public GameEngine(int width, int height)
        {
            gameBoard = new GameBoard(height, width);
            Player = new Player("JSmith", "John", "Smith");
            Player.Shoot += Player_Shoot;
        }

        private void Player_Shoot(int x, int y)
        {
            x = Convert.ToInt32(Math.Ceiling(Convert.ToInt32(x) / 30.01)) - 1;
            y = Convert.ToInt32(Math.Ceiling(Convert.ToInt32(y) / 30.01)) - 1;
            character = mineField[x, y];
            mineField[x, y] = "x";
            if (!character.Equals("x"))
                StateIsUpdated?.Invoke(x, y, character);
            if (!(character.Equals("*") || character.Equals("") || character.Equals("x")))
                nrFields--;
            if (nrFields == 0)
            {
                EndGame?.Invoke();
            }
        }

        Random random = new Random();
        public void LoadMineField()
        {
            int temp;
            for (int i = 0; i < 9; i++) //filling tables with zeroes
            {
                for (int j = 0; j < 9; j++)
                {
                    mineField[i, j] = "0";
                }
            }
            for (int i = 0; i < 10; i++) //mines generating
            {
                mineField[random.Next(0, 8), random.Next(0, 8)] = "*";
            }

            for (int i = 0; i < 9; i++) //generating fields with the number of mines nearby
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!(mineField[i, j].Contains("*")))
                    {
                        if (i == 0) //top line
                        {
                            if (j == 0)
                            {
                                if (mineField[i, j + 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i + 1, j + 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i + 1, j].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                            }
                            else if (j == 8)
                            {
                                if (mineField[i, j - 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i + 1, j - 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i + 1, j].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                            }
                            else
                            {
                                if (mineField[i, j + 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i, j - 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i + 1, j + 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i + 1, j].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i + 1, j - 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                            }
                        }
                        else if (i == 8) //bottom line
                        {
                            if (j == 0)
                            {
                                if (mineField[i, j + 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i - 1, j + 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i - 1, j].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                            }
                            else if (j == 8)
                            {
                                if (mineField[i, j - 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i - 1, j - 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i - 1, j].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                            }
                            else
                            {
                                if (mineField[i, j + 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i, j - 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i - 1, j + 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i - 1, j].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                                if (mineField[i - 1, j - 1].Contains("*"))
                                {
                                    temp = Convert.ToInt32(mineField[i, j]);
                                    ++temp;
                                    mineField[i, j] = Convert.ToString(temp);
                                }
                            }
                        }
                        else if (j == 0 && i != 0 && i != 8)
                        {
                            if (mineField[i - 1, j].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i + 1, j].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i - 1, j + 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i, j + 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i + 1, j + 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                        }
                        else if (j == 8 && i != 0 && i != 8)
                        {
                            if (mineField[i - 1, j].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i + 1, j].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i - 1, j - 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i, j - 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i + 1, j - 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                        }
                        else
                        {
                            if (mineField[i - 1, j].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i + 1, j].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i - 1, j + 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i, j + 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i + 1, j + 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i - 1, j - 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i, j - 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                            if (mineField[i + 1, j - 1].Contains("*"))
                            {
                                temp = Convert.ToInt32(mineField[i, j]);
                                ++temp;
                                mineField[i, j] = Convert.ToString(temp);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 9; i++) //count the number of lines which are filled with digits
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!(mineField[i, j].Contains("*") || mineField[i, j].Contains("0")))
                    {
                        nrFields++;
                    }
                }
            }

            for (int i = 0; i < 9; i++) //replace zero with blank
            {
                for (int j = 0; j < 9; j++)
                {
                    if (mineField[i, j].Contains("0"))
                        mineField[i, j] = "";
                }
            }
        }
        public void SaveMineField()
        {
            File.Delete(@"C:\\Users\\" + Environment.UserName + "\\mines.txt");
            using (StreamWriter w = File.AppendText("C:\\Users\\" + Environment.UserName + "\\mines.txt"))
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (mineField[i, j].Equals(""))
                        {
                            w.Write("0/");
                        }
                        else
                            w.Write(mineField[i, j] + "/");
                    }
                    w.WriteLine();
                }
                w.WriteLine(nrFields);
            }
        }
    }
}
