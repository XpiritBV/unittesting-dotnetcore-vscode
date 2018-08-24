using FluentAssertions;
using Moq;
using System;
using System.Linq;
using TicTacToe;
using Xunit;

namespace TicTacToe.Tests
{
    public class AvailablePositionsTests
    {
        [Fact]
        public void GivenEmptyGrid_WhenNoMovedHaveBeenMade_ThenAvailablePositionsShouldBeEqualToTotalPositions()
        {
            // Arrange
            var gameState = CreateGameState();
            var total = gameState.TotalPositionsCount;

            // Act
            var result = gameState.AvailablePositions;

            // Assert
            result.Should().HaveCount(total);
        }
        
        [Fact]
        public void GivenEmptyGrid_WhenOneMoveHasBeenMade_ThenAvailablePositionsShouldbeOneLessThanTotalPositions()
        {
            // Arrange
            var gameState = CreateGameState();
            var totalMinusOne = gameState.TotalPositionsCount - 1;

            // Act
            gameState.MakeMove(1, 0, 0);

            // Assert
            gameState.AvailablePositions.Should().HaveCount(totalMinusOne);
        }

        private static GameState CreateGameState()
        {
            var mockedEndGameStrategy = new Mock<IEndGameStrategy>();

            return new GameState(mockedEndGameStrategy.Object);
        }
    }
}
