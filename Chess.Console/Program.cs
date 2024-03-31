using Chess.Console;
using Chess.Main.GameFactory;
using Chess.Main.GameFactory.Factories;


IGameFactory gameFactory = new StandartGameFactory(new ChessConsoleRenderer());
var game = gameFactory.CreateGame();
game.StartGame();
