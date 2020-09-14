using NewGOmoku.GameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewGOmoku
{

    public static class Turn
    {
        public static Player playersTurn = new Player('x');

    }
    class Program
    {
        public static int BOARD_SIZE = 15;
        public static char EMPTY = '_';
        public static char PLAYER1 = 'x';
        public static char PLAYER2 = 'o';
        public static bool isTerminal(Game game)
        {
            return BoardValidation.Win(game.board.b, PLAYER1) || BoardValidation.Win(game.board.b, PLAYER2) || !game.isAnyMovesLeft();
        }

        public static int minimax(List<Move> locations, Game game, int depth, bool isMaxPlayer, int alpha, int beta)
        {
            var newValidLocations = new List<Move>();
            int score = getScoreEvaluation(game);
            if(depth == 0 || isTerminal(game))
            {
                if (BoardValidation.Win(game.board.b, PLAYER1))
                {
                    return 10000000;
                }
                if (BoardValidation.Win(game.board.b, PLAYER2))
                {
                    return -10000000;
                }
                if(!game.isAnyMovesLeft())
                {
                    return 0;
                }
                return score;
            }
            if (isMaxPlayer)
            {
                newValidLocations = game.playerOne.getValidLocations(game.board.b, game.playerOne);

                int bestMaxValue = -1000;
                foreach (var cell in newValidLocations)
                {
                    int row1 = game.playerOne.move.row;
                    int col1 = game.playerOne.move.col;
                    game.board.b[cell.row, cell.col] = Turn.playersTurn.Name;
                    Turn.playersTurn.Name = PLAYER2;
                    Turn.playersTurn.move.row = game.playerTwo.move.row;
                    Turn.playersTurn.move.col = game.playerTwo.move.col;
                    game.playerOne.move.row = row1;
                    game.playerOne.move.col = col1;
                    int moveValue = minimax(newValidLocations, game, depth--, false, alpha, beta);
                    bestMaxValue = Math.Max(bestMaxValue, moveValue);
                    alpha = Math.Max(alpha, bestMaxValue);
                    game.board.b[cell.row, cell.col] = EMPTY;
                    if (alpha >= beta)
                    {
                        break;
                    }

                }
                return bestMaxValue;
            }
            else
            {
                newValidLocations = game.playerTwo.getValidLocations(game.board.b, game.playerTwo);
                int bestMinValue = 1000;
                foreach (var cell in newValidLocations)
                {
                    int row1 = game.playerTwo.move.row;
                    int col1 = game.playerTwo.move.col;
                    game.board.b[cell.row, cell.col] = Turn.playersTurn.Name;
                    Turn.playersTurn.Name = PLAYER1;
                    Turn.playersTurn.move.row = game.playerOne.move.row;
                    Turn.playersTurn.move.col = game.playerOne.move.col;
                    game.playerTwo.move.row = row1;
                    game.playerTwo.move.col = col1;
                    int moveValue = minimax(newValidLocations, game, depth--, true, alpha, beta);
                    bestMinValue = Math.Min(bestMinValue, moveValue);
                    beta = Math.Min(alpha, bestMinValue);
                    game.board.b[cell.row, cell.col] = EMPTY;
                    if (alpha >= beta)
                    {
                        break;
                    }

                }
                return bestMinValue;
            }
        }

        public static Move makeBestMove(Game game, Player p, int depth)
        {
            
            var validLocations = p.getValidLocations(game.board.b, p);
            int bestVal = -1000;
            Move bestMove = new Move();
            bestMove.row = -1;
            bestMove.col = -1;
            
            // На каждый валидный ход из листа valid locations 
            foreach (var location in validLocations)
            {
                // делаем ход
                game.board.b[location.row, location.col] = p.Name;
                Turn.playersTurn.move.row = location.row;
                Turn.playersTurn.move.col = location.col;
               
                int moveValue = minimax(validLocations, game, depth, true, 0, 0);
                game.board.b[location.row, location.col] = Program.EMPTY;
                if (moveValue > bestVal)
                {
                    bestMove.row = location.row;
                    bestMove.col = location.col;
                    bestVal = moveValue;
                }
            }
            return bestMove;

        }

        public static int getScoreEvaluation(Game g)
        {
            int score = 0;

            var scoreList = new List<int>();
            var countList = new List<int>();
            scoreList.Add(score);
            
            var count = 0;
            countList.Add(count);
            int row = Turn.playersTurn.move.row;
            int col = Turn.playersTurn.move.col;
            if(row+4 <=11 && row-4 >= 0)
            {
                for (int i = row-4; i < row + 4; i++)
                {
                    if (g.board.b[i, col] == Turn.playersTurn.Name)
                    {
                        count++;
                        score += evaluateCell(Turn.playersTurn.Name, count);

                    }
                }
              
                countList.Add(count);
                scoreList.Add(score);

                score = 0;
                count = 0;
            }
          
            if(col +4 <=11 && col-4 >= 0)
            {
                for (int i = col-4; i < col + 4; i++)
                {
                    if (g.board.b[row, i] == Turn.playersTurn.Name)
                    {
                        count++;
                        score += evaluateCell(Turn.playersTurn.Name, count);
                    }
                }
                countList.Add(count);
                scoreList.Add(score);
                score = 0;
                count = 0;
            }
           
            if(col +4<= 11 && col -4>= 0 && row +4<= 11 && row -4>= 0)
            {
                for (int i = row-4; i < row + 4; i++)
                {
                    if (g.board.b[i, i] == Turn.playersTurn.Name)
                    {
                        count++;
                        score += evaluateCell(Turn.playersTurn.Name, count);
                    }
                }
                countList.Add(count);
                scoreList.Add(score);
                score = 0;
                count = 0;
            }

           
            if (Turn.playersTurn.Name == Program.PLAYER1)
            {
                score = scoreList.Max();
            }
            else
            {
                score = scoreList.Min();
            }
            return score;
        }
        public static int evaluateCell(char p, int count)
        {
            if(count == 1)
            {
                return 10;
            }
            else if(count == 2)
            {
                return 500;
            }
            else if(count == 3)
            {
                return 4000;
            }
            else if(count == 4)
            {
                return 1000000;
            }
            else if(count == 5)
            {
                return 1000000;
            }
            return 0;
        }
        static void Main(string[] args)
        {
            var game = new Game();
            while (!game.isGameOver())
            {
                if(Turn.playersTurn.Name == game.playerOne.Name)
                {
                    var newMove = makeBestMove(game, game.playerOne, 3);
                    game.board.makeNewMoveOnBoard(newMove, game.playerOne);
                    game.playerOne.move = newMove;
                    Console.WriteLine();
                    Turn.playersTurn.move = game.playerTwo.move;
                    Turn.playersTurn.Name = game.playerTwo.Name;
                    if(BoardValidation.Win(game.board.b, PLAYER1) == true)
                    {
                        Console.WriteLine("PLayer 1 Won");
                    }
                }
                else if(Turn.playersTurn.Name == game.playerTwo.Name)
                {
                    var newMove = makeBestMove(game, game.playerTwo, 3);
                    game.board.makeNewMoveOnBoard(newMove, game.playerTwo);
                    game.playerTwo.move = newMove;
                    Console.WriteLine();
                    Turn.playersTurn.move = game.playerOne.move;
                    Turn.playersTurn.Name = game.playerOne.Name;

                    if (BoardValidation.Win(game.board.b, PLAYER2) == true)
                    {
                        Console.WriteLine("PLayer 2 Won");
                    }
                }
                game.board.printOutNewBoard();
           

            }

            Console.ReadLine();
        }
    }
}
