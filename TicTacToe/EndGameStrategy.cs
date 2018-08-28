using System;

namespace TicTacToe
{
    public class EndGameStrategy : IEndGameStrategy
    {
        public (bool isGameComplete, int winner) Verify(int[,] grid)
        {
            (bool isGameComplete, int winner) result = (false, 0);
            int emptyPositionCount = 0;

            for (int x = GameConstants.Board.Min; x < GameConstants.Board.Size; x++)
            {
                int rowSum = 0; 
                int columnSum = 0;
                for (int y = GameConstants.Board.Min; y < GameConstants.Board.Size; y++)
                {
                    if (grid[x, y] == GameConstants.Values.Empty)
                    {
                        emptyPositionCount++;
                    }

                    rowSum = rowSum + grid[x, y];
                    columnSum = columnSum + grid[y, x];

                    if (x == GameConstants.Board.Middle && y == GameConstants.Board.Middle)
                    {
                        result = VerifyDiagonals(grid);
                    }
                }

                if (Math.Abs(rowSum) ==  GameConstants.Values.WinningScore)
                {
                    result = (true, GetPlayer(rowSum));
                }
                else if (Math.Abs(columnSum) == GameConstants.Values.WinningScore)
                {
                    result = (true, GetPlayer(columnSum));
                }

                if (result.isGameComplete)
                {
                    return result;
                }  
            }

            if (emptyPositionCount == 0)
            {
                // Equal outcome
                result = (true, GameConstants.Values.Empty);
            }

            return result;
        }

        private (bool isGameComplete, int winner) VerifyDiagonals(int[,] grid)
        {
            (bool isGameComplete, int winner) result = (false, GameConstants.Values.Empty);
            var topLeftBottomRightSum = grid[GameConstants.Board.Min, GameConstants.Board.Min] + grid[GameConstants.Board.Middle, GameConstants.Board.Middle] + grid[GameConstants.Board.Max, GameConstants.Board.Max];
            var bottomLeftTopRightSum = grid[GameConstants.Board.Max, GameConstants.Board.Min] + grid[GameConstants.Board.Middle, GameConstants.Board.Middle] + grid[GameConstants.Board.Min, GameConstants.Board.Max];

            if (Math.Abs(topLeftBottomRightSum) == GameConstants.Values.WinningScore)
            {
                result = (true, GetPlayer(topLeftBottomRightSum));
            }
            else if (Math.Abs(bottomLeftTopRightSum) == GameConstants.Values.WinningScore)
            {
                result = (true, GetPlayer(bottomLeftTopRightSum));
            }

            return result;
        }

        private static int GetPlayer(int score)
        {
            return Math.Sign(score);
        }
    }
}