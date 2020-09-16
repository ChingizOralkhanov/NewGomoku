using NewGOmoku.GameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewGOmoku
{

    public static class Turn
    {
        public static Player playersTurn = new Player('x');
        public static char PlayersTurn = 'x';
        public static int playersMoveRow = 0;
        public static int playersMoveCol = 0;
        public static void setNewLastPlayer(int lastRow, int lastCol, char name)
        {
            PlayersTurn = name;
        }
    }
    class Program
    {
        public static int BOARD_SIZE = 15;
        public static char EMPTY = '_';
        public static char PLAYER1 = 'x';
        public static char PLAYER2 = 'o';

        static void Main(string[] args)
        {
            var game = new Game();
            while (!game.isGameOver())
            {
                if(Turn.PlayersTurn == game.playerOne.Name)
                {
                    var move =  new Move();
                    var newMove = move.makeBestMove(game, game.playerOne, 2);
                    game.board.makeNewMoveOnBoard(newMove, game.playerOne);
                    game.playerOne.move = newMove;
                    Console.WriteLine();
                    if(BoardValidation.Win(game.board.b, PLAYER1) == true)
                    {
                        Console.WriteLine("PLayer 1 Won");
                    }
                    Turn.PlayersTurn = PLAYER2;
                }
                else if(Turn.PlayersTurn == game.playerTwo.Name)
                {
                    var move = new Move();
                    var newMove = move.makeBestMove(game, game.playerTwo, 1);
                    game.board.makeNewMoveOnBoard(newMove, game.playerTwo);
                    game.playerTwo.move = newMove;
                    Console.WriteLine();
                    if (BoardValidation.Win(game.board.b, PLAYER2) == true)
                    {
                        Console.WriteLine("PLayer 2 Won");
                    }
                    Turn.PlayersTurn = PLAYER1;
                }
                // TODO сделать оценку противника
                game.board.printOutNewBoard();
                Console.WriteLine();

            }

            Console.ReadLine();
        }
    }
}
