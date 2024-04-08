using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces.Move;

public interface IMove
{
    IEnumerable<Coordinate> Move(Coordinate coordinate, Board board, Color color);
}
