using FluentAssertions;
using System;
using System.Linq;
using TicTacToe;
using Xunit;

namespace TicTacToe.Tests
{
    public class DetectEndGameStrategyTests
    {
        [Fact]
        [Trait("Category","Strategy")]
        public void GivenEmptyBoard_WhenVerifyIsCalled_ThenGameCompleteShouldBeFalse()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var board = BoardFactory.CreateEmptyBoard();

            // Act
            var result = endGameStrategy.Verify(board);

            // Assert
            result.isGameComplete.Should().BeFalse();
        }

        [Fact]
        [Trait("Category","Strategy")]
        public void GivenBoardWithEqualOutCome_WhenVerifyIsCalled_ThenGameCompleteShouldBeTrue()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var board = BoardFactory.CreateBoardWithNoWin();

            // Act
            var result = endGameStrategy.Verify(board);

            // Assert
            result.isGameComplete.Should().BeTrue();
        }

        [Fact]
         [Trait("Category","Strategy")]
        public void GivenBoardWithEqualOutCome_WhenVerifyIsCalled_ThenPlayerShouldBe0()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var board = BoardFactory.CreateBoardWithNoWin();

            // Act
            var result = endGameStrategy.Verify(board);

            // Assert
            result.winner.Should().Be(0);
        }

        [Fact]
        [Trait("Category","Strategy")]
        public void GivenBoardWithWinOnFirstRow_WhenVerifyIsCalled_ThenGameCompleteShouldBeTrue()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var board = BoardFactory.CreateBoardWithWinOnFirstRow();

            // Act
            var result = endGameStrategy.Verify(board);

            // Assert
            result.isGameComplete.Should().BeTrue();
        }

        [Fact]
        [Trait("Category","Strategy")]
        public void GivenBoardWithWinOnFirstColumn_WhenVerifyIsCalled_ThenGameCompleteShouldBeTrue()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var board = BoardFactory.CreateBoardWithWinOnFirstColumn();

            // Act
            var result = endGameStrategy.Verify(board);

            // Assert
            result.isGameComplete.Should().BeTrue();
        }

        [Fact]
        [Trait("Category","Strategy")]
        public void GivenBoardWithWinOnDiagonalBottomLeftTopRight_WhenVerifyIsCalled_ThenGameCompleteShouldBeTrue()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var board = BoardFactory.CreateBoardWithWinOnDiagonalBottomLeftTopRight();

            // Act
            var result = endGameStrategy.Verify(board);

            // Assert
            result.isGameComplete.Should().BeTrue();
        }

        [Fact]
        [Trait("Category","Strategy")]
        public void GivenBoardWithWinOnDiagonalTopLeftBottomRight_WhenVerifyIsCalled_ThenGameCompleteShouldBeTrue()
        {
            // Arrange
            var endGameStrategy = CreateEndGameStrategy();
            var board = BoardFactory.CreateBoardWithWinOnDiagonalBottomLeftTopRight();

            // Act
            var result = endGameStrategy.Verify(board);

            // Assert
            result.isGameComplete.Should().BeTrue();
        }

        private static IEndGameStrategy CreateEndGameStrategy()
        {
            return new EndGameStrategy();
        }
   }
}
