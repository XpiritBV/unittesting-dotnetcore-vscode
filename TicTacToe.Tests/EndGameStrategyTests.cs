using FluentAssertions;
using System;
using System.Linq;
using TicTacToe;
using Xunit;

namespace TicTacToe.Tests
{
    public class DetectEndGameStrategyTest
    {
        [Fact]
        public void GivenEmptyGrid_WhenVerifyIsCalled_ThenGameCompleteShouldBeFalse()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var grid = GridFactory.CreateEmptyGrid();

            // Act
            var result = endGameStrategy.Verify(grid);

            // Assert
            result.isGameComplete.Should().BeFalse();
        }

        [Fact]
        public void GivenGridWithEqualOutCome_WhenVerifyIsCalled_ThenGameCompleteShouldBeTrue()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var grid = GridFactory.CreateGridWithNoWin();

            // Act
            var result = endGameStrategy.Verify(grid);

            // Assert
            result.isGameComplete.Should().BeTrue();
        }

        [Fact]
        public void GivenGridWithEqualOutCome_WhenVerifyIsCalled_ThenPlayerShouldBe0()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var grid = GridFactory.CreateGridWithNoWin();

            // Act
            var result = endGameStrategy.Verify(grid);

            // Assert
            result.winner.Should().Be(0);
        }

        [Fact]
        public void GivenGridWithWinOnFirstRow_WhenVerifyIsCalled_ThenGameCompleteShouldBeTrue()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var grid = GridFactory.CreateGridWithWinOnFirstRow();

            // Act
            var result = endGameStrategy.Verify(grid);

            // Assert
            result.isGameComplete.Should().BeTrue();
        }

        [Fact]
        public void GivenGridWithWinOnFirstColumn_WhenVerifyIsCalled_ThenGameCompleteShouldBeTrue()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var grid = GridFactory.CreateGridWithWinOnFirstColumn();

            // Act
            var result = endGameStrategy.Verify(grid);

            // Assert
            result.isGameComplete.Should().BeTrue();
        }

        [Fact]
        public void GivenGridWithWinOnDiagonalBottomLeftTopRight_WhenVerifyIsCalled_ThenGameCompleteShouldBeTrue()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var grid = GridFactory.CreateGridWithWinOnDiagonalBottomLeftTopRight();

            // Act
            var result = endGameStrategy.Verify(grid);

            // Assert
            result.isGameComplete.Should().BeTrue();
        }

        [Fact]
        public void GivenGridWithWinOnDiagonalTopLeftBottomRight_WhenVerifyIsCalled_ThenGameCompleteShouldBeTrue()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var grid = GridFactory.CreateGridWithWinOnDiagonalBottomLeftTopRight();

            // Act
            var result = endGameStrategy.Verify(grid);

            // Assert
            result.isGameComplete.Should().BeTrue();
        }

        private static IEndGameStrategy CreateEndGameStrategy()
        {
            return new EndGameStrategy();
        }
   }
}
