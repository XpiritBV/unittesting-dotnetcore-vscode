namespace TicTacToe.Tests
{
    internal class BoardFactory
    {
        internal static int[,] CreateEmptyBoard()
        {
            return new int[GameConstants.Board.Size, GameConstants.Board.Size]; 
        }

        internal static int[,] CreateBoardWithNoWin()
        {
            return new int[GameConstants.Board.Size, GameConstants.Board.Size]{
                {1, -1, 1},
                {-1, -1, 1},
                {1, 1, -1}
            };  
        }

        internal static int[,] CreateBoardWithWinOnFirstRow()
        {
            return new int[GameConstants.Board.Size, GameConstants.Board.Size] {
                {1, 1, 1},
                {0, -1, 0},
                {-1, -1, 1}
            }; 
        }

        internal static int[,] CreateBoardWithWinOnFirstColumn()
        {
            return new int[GameConstants.Board.Size, GameConstants.Board.Size] {
                {-1, 0, 1},
                {-1, 1, 0},
                {-1, 0, 1}
            }; 
        }

        internal static int[,] CreateBoardWithWinOnDiagonalBottomLeftTopRight()
        {
            return new int[GameConstants.Board.Size, GameConstants.Board.Size] {
                {-1, 0, 1},
                {-1, 1, 0},
                {1, 0, -1}
            }; 
        }

        internal static int[,] CreateBoardWithWinOnDiagonalTopLeftBottomRight()
        {
            return new int[GameConstants.Board.Size, GameConstants.Board.Size] {
                {-1, 0, 1},
                {1, -1, 0},
                {1, 0, -1}
            }; 
        }
    }
}