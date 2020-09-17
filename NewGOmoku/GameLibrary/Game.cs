using System;
using System.Collections.Generic;
using System.Text;

namespace NewGOmoku.GameLibrary
{
    public class Game
    {
        public Board board { get; set; }
        public Player playerOne { get; set; }
        public Player playerTwo { get; set; }

        /// <summary>
        /// Конструктор новой игры с первым и вторым ходом сразу
        /// </summary>
        public Game()
        {
            board = new Board();
            playerOne = new Player('x');
            playerTwo = new Player('o');
            Console.WriteLine("Welcome to a new Game");
            strikeFirst(board.b, playerOne);
            secondMove(board.b, playerTwo);

            board.printOutNewBoard();
        }

        /// <summary>
        /// Первый ход
        /// </summary>
        /// <param name="b"></param>
        /// <param name="player"></param>
        public void strikeFirst(char[,] b, Player player)
        {
            b[7, 7] = player.Name;
            player.move.col = 7;
            player.move.row = 7;
            Turn.PlayersTurn = playerTwo.Name;
            player.countsToWin++;
        }
        /// <summary>
        /// Второй ход
        /// </summary>
        /// <param name="b"></param>
        /// <param name="player"></param>
        public void secondMove(char[,] b, Player player)
        {
            b[7, 6] = player.Name;
            player.move.row = 7;
            player.move.col = 6;
            Turn.PlayersTurn = playerOne.Name; ;
            player.countsToWin++;
        }

        /// <summary>
        ///  Проверка на конец игры, победили выйграли или не осталось свободных мест   
        /// </summary>
        /// <returns>is Game is Over(won, lost, or not empty spaces)</returns>
        public bool isGameOver()
        {
            if (BoardValidation.Win(board.b, playerOne.Name) || BoardValidation.Win(board.b, playerTwo.Name) || !isAnyMovesLeft())
            {
                return true;
            }
            else return false;
        }
        public bool isAnyMovesLeft()
        {
            for (int i = 0; i < Program.BOARD_SIZE; i++)
            {
                for (int j = 0; j < Program.BOARD_SIZE; j++)
                {
                    if(board.b[i, j ] == '_')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Распечатка доски
        /// </summary>
        /// <param name="board"></param>
        public void printOutBoard()
        {
            for (int i = 0; i < Program.BOARD_SIZE; i++)
            {
                for (int j = 0; j < Program.BOARD_SIZE; j++)
                {
                    Console.Write($" {board.b[i, j] }");
                }
                Console.WriteLine();
            }
        }
    }
}
