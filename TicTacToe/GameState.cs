using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TicTacToe
{
    public class GameState
    {
        private int[,] grid;
        private readonly IEndGameStrategy endGameStrategy;

        public GameState(IEndGameStrategy endGameStrategy)
        {
            grid = new int[GameConstants.GridSize, GameConstants.GridSize];
            this.endGameStrategy = endGameStrategy;
        }

        public (bool isGameComplete, string message) MakeMove(int player, int xPosition, int yPosition)
        {
            var move = (player: player, x: xPosition, y: yPosition);
            (bool isGameComplete, string message) result;

            if (grid[move.x, move.y] == GameConstants.EmptyValue)
            {
                grid[move.x, move.y] = move.player;
                var endGameResult = endGameStrategy.Verify(grid);
                result = (endGameResult.isGameComplete, "$(endGameResult.winner)");
            }
            else
            {
                result = (false, "Oops, this position is already taken, please try again.");
            }
            
            return result;
        }

        public IEnumerable<(int x, int y)> AvailablePositions => GetAvailablePositions();

        public int TotalPositionsCount => GameConstants.GridSize * GameConstants.GridSize;  

        private IEnumerable<(int, int)> GetAvailablePositions()
        {
            for (int x = 0; x < GameConstants.GridSize; x++)
            {
                for (int y = 0; y < GameConstants.GridSize; y++)
                {
                    if (grid[x, y] == GameConstants.EmptyValue)
                    {
                        yield return (x, y);
                    }
                }
            }
        }
    }
}