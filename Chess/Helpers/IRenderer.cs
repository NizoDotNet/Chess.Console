using Chess.Main;
using Chess.Pieces;

namespace Chess.Helpers;

public interface IRenderer
{
    void Render(Board board);
    Coordinate AskMove(Color color, Board board);
    Coordinate ShowAvaibleMoves(IList<Coordinate> coordinates);
    void Error(string message);
    Piece Promation(Color color);
}
