using Chess.Helpers;

namespace Chess.Main.GameFactory.Games;

internal class NoRenderer : IGame
{
    public NoRenderer()
    {
        Board = new Board();
    }

    public Board Board { get; set; }

    public IRenderer Renderer => throw new NotImplementedException();

    public void StartGame()
    {
        Board.SetFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR", null);

    }
}
