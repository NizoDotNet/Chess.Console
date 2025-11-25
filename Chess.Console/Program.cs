using Chess.Console;
using Chess.Main;
using Chess.Main.GameFactory;
using Chess.Main.GameFactory.Factories;

var renderer = new ChessConsoleRenderer();
IGameFactory gameFactory = new StandartGameFactory(renderer);
var game = gameFactory.CreateGame();
game.StartGame("8/8/5b2/8/3R4/2KN2r1/8/7k");
