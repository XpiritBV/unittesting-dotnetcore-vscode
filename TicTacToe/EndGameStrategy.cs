using System;

namespace TicTacToe
{
    public class EndGameStrategy : IEndGameStrategy
    {
        public (bool isGameComplete, int winner) Verify(int[,] grid)
        {
            (bool isGameComplete, int winner) result = (false, 0);
            int emptyPositionCount = 0;

            for (int x = 0; x < GameConstants.GridSize; x++)
            {
                int rowSum = 0; 
                int columnSum = 0;
                for (int y = 0; y < GameConstants.GridSize; y++)
                {
                    if (grid[x, y] == GameConstants.EmptyValue)
                    {
                        emptyPositionCount++;
                    }

                    rowSum = rowSum + grid[x, y];
                    columnSum = columnSum + grid[y, x];

                    if (x == 1 && y == 1)
                    {
                        result = VerifyDiagonals(grid);
                    }
                }

                if (Math.Abs(rowSum) ==  GameConstants.WinningScore)
                {
                    result = (true, GetPlayer(rowSum));
                }
                else if (Math.Abs(columnSum) == GameConstants.WinningScore)
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
                result = (true, GameConstants.EmptyValue);
            }

            return result;
        }

        private (bool isGameComplete, int winner) VerifyDiagonals(int[,] grid)
        {
            (bool isGameComplete, int winner) result = (false, 0);
            var topLeftBottomRightSum = grid[0, 0] + grid[1, 1] + grid[2, 2];
            var bottomLeftTopRightSum = grid[2, 0] + grid[1, 1] + grid[0, 2];

            if (Math.Abs(topLeftBottomRightSum) == GameConstants.WinningScore)
            {
                result = (true, GetPlayer(topLeftBottomRightSum));
            }
            else if (Math.Abs(bottomLeftTopRightSum) == GameConstants.WinningScore)
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