using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces.Move;

public interface IMove
{
    List<Coordinate> Move(Coordinate coordinate, Board board, Color color);
}
