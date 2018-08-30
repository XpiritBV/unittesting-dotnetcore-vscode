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
        public void GivenEmptyBoard_WhenOneMoveHasBeenMade_ThenAvailablePositionsShouldBeOneLessThanTotalPositions()
        {
            // Arrange
            var engine = CreateGameEngine();
            var totalMinusOne = engine.TotalPositionsCount - 1;

            // Act
            engine.MakeMove(1, 0, 0);

            // Assert
            engine.AvailablePositions.Should().HaveCount(totalMinusOne);
        }

        [Fact]
        public void GivenEmptyBoard_WhenNineMovesHaveBeenMade_ThenAvailablePositionsShouldBeZero()
        {
            // Arrange
            var engine = CreateGameEngine();
            
            // Act
            engine.MakeMove(1, 0, 0);
            engine.MakeMove(-1, 1, 1);
            engine.MakeMove(1, 2, 2);
            engine.MakeMove(-1, 0, 2);
            engine.MakeMove(1, 2, 0);
            engine.MakeMove(-1, 2, 1);
            engine.MakeMove(1, 0, 1);
            engine.MakeMove(-1, 1, 0);
            engine.MakeMove(-1, 1, 2);

            // Assert
            engine.AvailablePositions.Should().HaveCount(0);
        }

        private static GameEngine CreateGameEngine()
        {
            var fakeEndGameStrategy = Substitute.For<IEndGameStrategy>();

            return new GameEngine(fakeEndGameStrategy);
        }
    }
}
