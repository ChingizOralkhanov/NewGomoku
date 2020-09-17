using NewGOmoku.GameLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewGOmoku
{
    public static class BoardValidation
    {
        public static int maxx = Program.BOARD_SIZE;
        public static int maxy = Program.BOARD_SIZE;

        public static bool ValidateAll(Player p)
        {
            return p.move.row <= 11 && p.move.row > 0 && p.move.col <= 11 && p.move.col >= 0;
        }
        public static int WinCount(char[,] board, char i)
        {

            // DiagonalCheckArray
            int[] pd1 = new int[maxx + maxy];
            // NegativeDiagonal CheckArray
            int[] pd2 = new int[maxx + maxy];

            // HorizontalCheckArray
            int[] pdy = new int[maxx];
            //pdy[x] horizontal check
            for (int y = 0; y < maxy; ++y)
            {
                //VerticalCheck
                int pdx = 0;

                for (int x = 0; x < maxx; ++x)
                {
                    int pd1_idx = x - y + (maxy - 1);
                    int pd2_idx = x + y;


                    if (board[x, y] == i)
                    {

                        if (++pd1[pd1_idx] == 5 || ++pd2[pd2_idx] == 5 || ++pdy[x] == 5 || ++pdx == 5)
                        {
                            if (board[x, y] == 'x')
                            {
                                return 10000;
                            }
                            else if (board[x, y] == 'o')
                            {
                                return -1000;
                            }
                        }

                    }
                    else
                    {
                        // reset numbers
                        pd1[pd1_idx] = 0;
                        pd2[pd2_idx] = 0;
                        pdy[x] = 0;
                        pdx = 0;
                    }
                }
            }

            return 0;


        }

        /// <summary>
        /// Оценка победы одного из игроков на доске
        /// </summary>
        /// <param name="board"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool Win(char[,] b, char p)
        {
            if(checkDiagonal(b, p) || checkDiagonalSloped(b, p) || checkVerticalDown(b, p) || checkVerticalUP(b, p) || checkHorizontalRight(b, p) || checkHorizontalLeft(b,p) == true)
            {
                return true;
            }
            return false;
        }
        public static bool checkDiagonal(char[,] b, char p)
        {
            //checkDiagonal
            for (int i = 4; i < Program.BOARD_SIZE; i++)
            {
                for (int j = 4; j < Program.BOARD_SIZE ; j++)
                {
                    if (b[i, j] == p && b[i, j] == b[i + 1, j + 1] && b[i + 1, j + 1] == b[i + 2, j + 2] && b[i + 2, j + 2] == b[i + 3, j + 3] && b[i + 3, j + 3] == b[i + 4, j + 4])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool checkDiagonalSloped(char[,] b, char p)
        {
            //checkDiagonalPosSloped
            for (int i = 4; i < Program.BOARD_SIZE; i++)
            {
                for (int j = 0; j < Program.BOARD_SIZE - 4; j++)
                {
                    if (b[i, j] == p && b[i, j] == b[i + 1, j - 1] && b[i + 1, j - 1] == b[i + 2, j - 2] && b[i + 2, j - 2] == b[i + 3, j - 3] && b[i + 3, j - 3] == b[i + 4, j - 4])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool checkHorizontalLeft(char[,] b, char p)
        {
            //checkHorizontalTOtheLEft
            for (int i = 0; i < Program.BOARD_SIZE; i++)
            {
                for (int j = 4; j < Program.BOARD_SIZE; j++)
                {
                    if (b[i, j] == p && b[i, j] == b[i, j - 1] && b[i, j - 1] == b[i, j - 2] && b[i, j - 1] == b[i, j - 3] && b[i, j - 3] == b[i, j - 4])
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        public static bool checkHorizontalRight(char[,] b, char p)
        {
            //checkHorizontalTOtheRight
            for (int i = 0; i < Program.BOARD_SIZE; i++)
            {
                for (int j = 0; j < Program.BOARD_SIZE - 4; j++)
                {
                    if (b[i, j] == p && b[i, j] == b[i, j + 1] && b[i, j + 1] == b[i, j + 2] && b[i, j + 1] == b[i, j + 3] && b[i, j + 3] == b[i, j + 4])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool checkVerticalDown(char[,] b, char p)
        {
            // checkVerticalDown
            for (int i = 0; i < Program.BOARD_SIZE - 4; i++)
            {
                for (int j = 0; j < Program.BOARD_SIZE; j++)
                {
                    if (b[i, j] == p && b[i, j] == b[i + 1, j] && b[i + 1, j] == b[i + 2, j] && b[i + 2, j] == b[i + 3, j] && b[i + 3, j] == b[i + 4, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Проверка вверх
        /// </summary>
        /// <param name="b"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool checkVerticalUP(char[,] b, char p)
        {
            for (int i = 4; i < Program.BOARD_SIZE; i++)
            {
                for (int j = 0; j < Program.BOARD_SIZE; j++)
                {
                    if (b[i, j] == p && b[i, j] == b[i - 1, j] && b[i - 1, j] == b[i - 2, j] && b[i - 2, j] == b[i - 3, j] && b[i - 3, j] == b[i - 4, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
