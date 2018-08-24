namespace TicTacToe.Tests
{
    internal class GridFactory
    {
        internal static int[,] CreateEmptyGrid()
        {
            return new int[GameConstants.GridSize, GameConstants.GridSize]; 
        }

        internal static int[,] CreateGridWithNoWin()
        {
            return new int[GameConstants.GridSize, GameConstants.GridSize]{
                {1, -1, 1},
                {-1, -1, 1},
                {1, 1, -1}
            };  
        }

        internal static int[,] CreateGridWithWinOnFirstRow()
        {
            return new int[GameConstants.GridSize, GameConstants.GridSize] {
                {1, 1, 1},
                {0, -1, 0},
                {-1, -1, 1}
            }; 
        }

        internal static int[,] CreateGridWithWinOnFirstColumn()
        {
            return new int[GameConstants.GridSize, GameConstants.GridSize] {
                {-1, 0, 1},
                {-1, 1, 0},
                {-1, 0, 1}
            }; 
        }

        internal static int[,] CreateGridWithWinOnDiagonalBottomLeftTopRight()
        {
            return new int[GameConstants.GridSize, GameConstants.GridSize] {
                {-1, 0, 1},
                {-1, 1, 0},
                {1, 0, -1}
            }; 
        }

        internal static int[,] CreateGridWithWinOnDiagonalTopLeftBottomRight()
        {
            return new int[GameConstants.GridSize, GameConstants.GridSize] {
                {-1, 0, 1},
                {1, -1, 0},
                {1, 0, -1}
            }; 
        }
    }
}