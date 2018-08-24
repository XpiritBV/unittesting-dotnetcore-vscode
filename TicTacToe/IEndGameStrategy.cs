namespace TicTacToe
{
    public interface IEndGameStrategy
    {
        (bool isGameComplete, int winner) Verify(int[,] grid);
    }
}