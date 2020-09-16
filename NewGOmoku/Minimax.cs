using NewGOmoku.GameLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewGOmoku
{
    public class MinimaxModel
    {
        public static int BOARD_SIZE = 15;
        public static char EMPTY = '_';
        public static char PLAYER1 = 'x';
        public static char PLAYER2 = 'o';
        public ScoreEvaluation evaluate {get;set;} = new ScoreEvaluation();
        /// <summary>
        /// Минимакс с выбором ходов с листа доступных ходов
        /// </summary>
        /// <param name="locations"></param>
        /// <param name="game"></param>
        /// <param name="depth"></param>
        /// <param name="isMaxPlayer"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <returns></returns>
        public int m( Game game, int depth, bool isMaxPlayer, int alpha, int beta)
        {
            var newValidLocations = new List<Move>();
            int score = evaluate.getScoreEvaluation(game);
            if (depth == 0 || game.isGameOver())
            {
                if (BoardValidation.Win(game.board.b, PLAYER1))
                {
                    return 10000000;
                }
                if (BoardValidation.Win(game.board.b, PLAYER2))
                {
                    return -10000000;
                }
                if (!game.isAnyMovesLeft())
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
   
                    game.board.b[cell.row, cell.col] = Program.PLAYER1;
                    Turn.PlayersTurn = Program.PLAYER2;
                    //game.playerOne.move.row = cell.row;
                    //game.playerOne.move.col = cell.col;
                    int moveValue = m( game, depth--, false, alpha, beta);
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

                    game.board.b[cell.row, cell.col] = Program.PLAYER2;
                    Turn.PlayersTurn = PLAYER1;
                    //game.playerTwo.move.row = cell.row;
                    //game.playerTwo.move.col = cell.col;
                    int moveValue = m(game, depth--, true, alpha, beta);
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
    }
}
