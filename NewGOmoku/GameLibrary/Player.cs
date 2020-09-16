using NewGOmoku.ValidationLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewGOmoku.GameLibrary
{
    public class Player
    {

        public char Name { get; set; }
        /// <summary>
        /// поледний ход
        /// </summary>
        public Move move { get; set; }
        /// <summary>
        /// Лист всех сделанных ходов игрока
        /// </summary>
        public List<Move> moves { get; set; }
        public int countsToWin = 5;
        public Player(char name)
        {
            Name = name;
            move = new Move();
            moves = new List<Move>();
            move.row = -1;
            move.col = -1;
            moves.Add(move);

        }
    

        public bool isValidLocation(char[,] b, int row, int col)
        {
            return b[row, col] == '_';
        }

        /// <summary>
        ///  Получаем Лист с всеми пустыми ячейками на доске для определенного игрока
        /// </summary>
        /// <param name="b"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public List<Move> getValidLocations(char[,] b, Player player)
        {
            int row = player.move.row;
            int col = player.move.col;
            var listOfValidLocations = new List<Move>();
            if (BoardValidation.ValidateAll(player))
            {
                if (b[row - 1, col] == '_')
                {
                    var move = new Move();
                    move.row = row - 1;
                    move.col = col;
                    listOfValidLocations.Add(move);
                }
                if (b[row, col - 1] == '_')
                {
                    var move = new Move();
                    move.row = row;
                    move.col = col - 1;
                    listOfValidLocations.Add(move);
                }
                if (b[row + 1, col] == '_')
                {
                    var move = new Move();
                    move.row = row + 1;
                    move.col = col;
                    listOfValidLocations.Add(move);
                }
                if (b[row, col + 1] == '_')
                {
                    var move = new Move();
                    move.row = row;
                    move.col = col + 1;
                    listOfValidLocations.Add(move);
                }
                if (b[row + 1, col + 1] == '_')
                {
                    var move = new Move();
                    move.row = row + 1;
                    move.col = col + 1;
                    listOfValidLocations.Add(move);
                }
                if (b[row - 1, col - 1] == '_')
                {
                    var move = new Move();
                    move.row = row - 1;
                    move.col = col - 1;
                    listOfValidLocations.Add(move);
                }
                if (b[row - 1, col + 1] == '_')
                {
                    var move = new Move();
                    move.row = row - 1;
                    move.col = col + 1;
                    listOfValidLocations.Add(move);
                }
                if (b[row + 1, col - 1] == '_')
                {
                    var move = new Move();
                    move.row = row + 1;
                    move.col = col - 1;
                    listOfValidLocations.Add(move);
                }
            }

            return listOfValidLocations;
        }
    }
}
