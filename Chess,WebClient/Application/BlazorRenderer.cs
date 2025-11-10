using Chess.Helpers;
using Chess.Main;
using Chess.Pieces;

namespace Chess.WebClient.Application;

public class BlazorRenderer : IRenderer
{
    private readonly Action _onRender;

    public BlazorRenderer(Action onRender)
    {
        _onRender = onRender;
    }

    public void Render(Board board)
    {
        _onRender?.Invoke();
    }

    public Coordinate AskMove(Color color, Board board)
    {
        return default;
    }

    public Coordinate ShowAvaibleMoves(IList<Coordinate> coordinates)
    {
        return default;
    }

    public void Error(string message)
    {
        Console.WriteLine($"Error: {message}");
    }

    public void IsCheck()
    {
        Console.WriteLine("Check!");
    }

    public Piece Promation(Color color)
    {
        return new Queen(color);
    }
}
