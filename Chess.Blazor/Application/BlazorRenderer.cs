using Chess.Helpers;
using Chess.Main;
using Chess.Pieces;

namespace Chess.Blazor.Application;

public class BlazorRenderer : IRenderer
{
    public Coordinate AskMove(Color color, Board board)
    {
        throw new NotImplementedException();
    }

    public void Error(string message)
    {
        throw new NotImplementedException();
    }

    public void IsCheck()
    {
        throw new NotImplementedException();
    }

    public Piece Promation(Color color)
    {
        throw new NotImplementedException();
    }

    public void Render(Board board)
    {
        throw new NotImplementedException();
    }

    public Coordinate ShowAvaibleMoves(IList<Coordinate> coordinates)
    {
        throw new NotImplementedException();
    }
}
