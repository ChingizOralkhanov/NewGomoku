using NewGOmoku.GameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewGOmoku
{
    public class ScoreEvaluation
    {
        /// <summary>
        /// Подсчитывает максимальное количество очков для разных вариаций хода
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public  int getScoreEvaluation(Game g)
        {
            int score = 0;

            var scoreList = new List<int>();
            var countList = new List<int>();
            scoreList.Add(score);

            var count = 0;
            countList.Add(count);
            int row = 0;
            int col = 0;
            if(Turn.PlayersTurn == Program.PLAYER1)
            {
                row = g.playerOne.move.row;
                col = g.playerOne.move.col;
            }
            else if(Turn.PlayersTurn == Program.PLAYER2)
            {
                row = g.playerTwo.move.row;
                col = g.playerTwo.move.col;
            }
            // Проверка по вертикали
            if (row + 4 <= 11 && row - 4 >= 0)
            {
                for (int i = row - 4; i < row + 4; i++)
                {
                    if (g.board.b[i, col] == Turn.PlayersTurn)
                    {
                        count++;
                        score += evaluateCell(Turn.PlayersTurn, count);

                    }
                }

                countList.Add(count);
                scoreList.Add(score);

                score = 0;
                count = 0;
            }
            // Проверка по горизонтали
            if (col + 4 <= 11 && col - 4 >= 0)
            {
                for (int i = col - 4; i < col + 4; i++)
                {
                    if (g.board.b[row, i] == Turn.PlayersTurn)
                    {
                        count++;
                        score += evaluateCell(Turn.PlayersTurn, count);
                    }
                }
                countList.Add(count);
                scoreList.Add(score);
                score = 0;
                count = 0;
            }

            if (col + 4 <= 11 && col - 4 >= 0 && row + 4 <= 11 && row - 4 >= 0)
            {
                for (int i = row - 4; i < row + 4; i++)
                {
                    if (g.board.b[i, i] == Turn.PlayersTurn)
                    {
                        count++;
                        score += evaluateCell(Turn.PlayersTurn, count);
                    }
                }
                countList.Add(count);
                scoreList.Add(score);
                score = 0;
                count = 0;
            }

            score = scoreList.Max();

            return score;
        }


        /// <summary>
        ///  
        /// </summary>
        /// <param name="p"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public  int evaluateCell(char p, int count)
        {
            if (count == 1)
            {
                return 10;
            }
            else if (count == 2)
            {
                return 500;
            }
            else if (count == 3)
            {
                return 4000;
            }
            else if (count == 4)
            {
                return 1000000;
            }
            else if (count == 5)
            {
                return 1000000;
            }
            return 0;
        }
    }
}
