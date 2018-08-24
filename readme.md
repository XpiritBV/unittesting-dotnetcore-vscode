# Unit testing a .NET Core project in VS Code

This repo contains a .NET Core project to help illustrate how unit testing can be done using in VS Code.

## TicTacToe project

The .NET Core project is an (incomplete) implementation of a TicTacToe game which can be played by two players. 

The state of the game is captured in the [`GameState.cs`](TicTacToe\GameState.cs) class. The verification of completion of the game (and the winner) is implemented in the [`EndGameStrategy.cs`](TicTacToe\EndGameStrategy.cs) class.

### Positions on the board

Positions on the board are defined as x,y coordinates in a 3x3 2D array:
    
```
    0,0 | 0,1 | 0,2
   -----|-----|-----
    1,0 | 1,1 | 1,2
   -----|-----|-----
    2,0 | 2,1 | 2,2
``` 

### Values on the board

A position can hold on of these three values: 1, -1 or 0.
Values 1 and -1 are the two players.
A value of 0 means that the position is still empty.

A winning game is determined by summation of the values in either the rows, columns or diagonals.

#### _Examples_ 

_Player 1 wins:_
``` 
     1  |  0  | -1
   -----|-----|-----
    -1  | -1  |  0
   -----|-----|-----
     1  |  1  |  1 
```

_Player -1 wins:_
``` 
     1  |  0  | -1
   -----|-----|-----
    -1  | -1  |  0
   -----|-----|-----
    -1  |  1  |  1 
```

_Equal outcome:_
``` 
     1  | -1  |  1
   -----|-----|-----
    -1  |  1  |  1
   -----|-----|-----
    -1  |  1  | -1 
```

## Unit test project

The `EndGameStrategy.cs` class contains plenty of logic to be unit tested. These tests can be found in [`EndGameStrategyTests.cs`](TicTacToe.Tests\EndGameStrategyTests.cs).

The [`AvailablePositionsTests.cs`](TicTacToe.Tests\AvailablePositionsTests.cs) class contains some examples of unit tests with a mocked `IEndGameStrategy`.