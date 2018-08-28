using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TicTacToe
{
    public class GameEngine
    {
        private int[,] board;
        private readonly IEndGameStrategy endGameStrategy;

        public GameEngine(IEndGameStrategy endGameStrategy)
        {
            board = new int[GameConstants.Board.Size, GameConstants.Board.Size];
            this.endGameStrategy = endGameStrategy;
        }

        public (bool isGameComplete, string message) MakeMove(int player, int xPosition, int yPosition)
        {
            var move = (player: player, x: xPosition, y: yPosition);
            (bool isGameComplete, string message) result;

            if (board[move.x, move.y] == GameConstants.Values.Empty)
            {
                board[move.x, move.y] = move.player;
                var endGameResult = endGameStrategy.Verify(board);
                result = (endGameResult.isGameComplete, "$(endGameResult.winner)");
            }
            else
            {
                result = (false, "Oops, this position is already taken, please try again.");
            }
            
            return result;
        }

        public IEnumerable<(int x, int y)> AvailablePositions => GetAvailablePositions();

        public int TotalPositionsCount => GameConstants.Board.Size * GameConstants.Board.Size;  

        private IEnumerable<(int, int)> GetAvailablePositions()
        {
            for (int x = GameConstants.Board.Min; x < GameConstants.Board.Size; x++)
            {
                for (int y = GameConstants.Board.Min; y < GameConstants.Board.Size; y++)
                {
                    if (board[x, y] == GameConstants.Values.Empty)
                    {
                        yield return (x, y);
                    }
                }
            }
        }
    }
}