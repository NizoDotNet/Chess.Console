using Chess.Helpers;

namespace Chess.Main.GameFactory;

public interface IGame
{
    public Board Board { get; set; }
    void StartGame(string? fen = null);
}