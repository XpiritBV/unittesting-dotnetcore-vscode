using FluentAssertions;
using NSubstitute;
using System;
using System.Linq;
using TicTacToe;
using Xunit;

namespace TicTacToe.Tests
{
    public class AvailablePositionsTests
    {
        [Fact]
        public void GivenEmptyBoard_WhenNoMovedHaveBeenMade_ThenAvailablePositionsShouldBeEqualToTotalPositions()
        {
            // Arrange
            var engine = CreateGameEngine();
            var total = engine.TotalPositionsCount;

            // Act
            var result = engine.AvailablePositions;

            // Assert
            result.Should().HaveCount(total);
        }
        
        [Fact]
        public void GivenEmptyBoard_WhenOneMoveHasBeenMade_ThenAvailablePositionsShouldbeOneLessThanTotalPositions()
        {
            // Arrange
            var engine = CreateGameEngine();
            var totalMinusOne = engine.TotalPositionsCount - 1;

            // Act
            engine.MakeMove(1, 0, 0);

            // Assert
            engine.AvailablePositions.Should().HaveCount(totalMinusOne);
        }

        private static GameEngine CreateGameEngine()
        {
            var fakeEndGameStrategy = Substitute.For<IEndGameStrategy>();

            return new GameEngine(fakeEndGameStrategy);
        }
    }
}
