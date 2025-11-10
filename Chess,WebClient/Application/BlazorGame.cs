
using Chess.Helpers;
using Chess.Main;
using Chess.Main.GameFactory;

namespace Chess.WebClient.Application;

public class BlazorGame : IGame
{
    public Board Board { get; set; }
    public IRenderer Renderer { get; }

    public BlazorGame(IRenderer renderer)
    {
        Renderer = renderer;
        Board = new Board();
    }

    public void StartGame()
    {
        string startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
        Board.SetFen(startFen, Renderer.Promation);

        Renderer.Render(Board);
    }
}
