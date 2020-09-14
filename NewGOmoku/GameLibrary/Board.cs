using System;
using System.Collections.Generic;
using System.Text;

namespace NewGOmoku.GameLibrary
{
    public class Board
    {
        public const int boardSize = 15;
        public char[,] b { get; set; }
        public Board()
        {
            b = new char[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    b[i, j] = '_';
                }
            }
        }
        public void printOutNewBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write($" {b[i, j] }");
                }
                Console.WriteLine();
            }
        }
        public void makeNewMoveOnBoard(Move m, Player p)
        {
            b[m.row, m.col] = p.Name;
        }
    }
}
