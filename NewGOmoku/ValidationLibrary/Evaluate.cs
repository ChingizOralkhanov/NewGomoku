using System;
using System.Collections.Generic;
using System.Text;
using NewGOmoku.GameLibrary;
namespace NewGOmoku.ValidationLibrary
{
    public class Evaluate
    {
        public char[,] nearbyCells { get; set; }
        public char[,] collectedNearbyCells(char[,] board, int row, int col)
        {
            nearbyCells = new char[9, 9];

            for (int i = 0; i < Program.BOARD_SIZE; i++)
            {

            }

            return nearbyCells;
        }



    }
}
