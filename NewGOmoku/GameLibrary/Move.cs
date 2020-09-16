using System;
using System.Collections.Generic;
using System.Text;

namespace NewGOmoku.GameLibrary
{
    public class Move
    {
        public int row { get; set; }
        public int col { get; set; }


        /// <summary>
        /// Выбор наилучшего хода
        /// </summary>
        /// <param name="game"></param>
        /// <param name="p"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public Move makeBestMove(Game game, Player p, int depth)
        {
            var minimax = new MinimaxModel();
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
                Turn.playersMoveCol = location.col;
                Turn.playersMoveRow = location.row;

                if(p.Name == Program.PLAYER1)
                {
                    Turn.PlayersTurn = Program.PLAYER2;
                }
                else if (p.Name == Program.PLAYER2)
                {
                    Turn.PlayersTurn = Program.PLAYER1;
                }

                p.move.col = location.col;
                p.move.row = location.row;
     


                int moveValue = minimax.m (game, depth, false, 0, 0);
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
    }
}
