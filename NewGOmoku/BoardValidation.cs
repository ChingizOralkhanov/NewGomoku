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

        public static bool validateRows()
        {
            return Turn.playersTurn.move.row <= 11 && Turn.playersTurn.move.row >= 0;
        }
        public static bool validateCols()
        {
            return Turn.playersTurn.move.col <= 11 && Turn.playersTurn.move.col >= 0;
        }
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
        public static bool Win(char[,] board, char i)
        {

           
            int[] verticalCheckArray = new int[30];
            int[] horizontalCheckArray = new int[30];
            int[] diagonalarray = new int[maxx];
      
            for (int y = 0; y < maxy; ++y)
            {
                int index = 0;
                for (int x = 0; x < maxx; ++x)
                {
                    int verticalIndex = x - y + (maxy - 1);
                    int horizontalIndex = x + y;
                    if (board[x, y] == i)
                    {

                        if (++verticalCheckArray[verticalIndex] == 5 || ++horizontalCheckArray[horizontalIndex] == 5 || ++diagonalarray[x] == 5 || ++index == 5)
                        {
                            if (board[x, y] == i)
                            {
                                return true;
                            }
                    
                        }

                    }
                    else
                    {
                        verticalCheckArray[verticalIndex] = 0;
                        horizontalCheckArray[horizontalIndex] = 0;
                        diagonalarray[x] = 0;
                        index = 0;
                    }
                }
            }
            return false;
        }
    }
}
