using Chess.Main;

namespace Chess.Helpers;

public interface IRenderer
{
    void Render(Board board);
    (Coordinate, Coordinate) AskMove(Color color);

    void Error(string message);
}
