using Chess.Helpers;

namespace Chess.Main.GameFactory;

public interface IGame
{
    public Board Board { get; set; }
    public IRenderer Renderer { get; }
    void StartGame();
}