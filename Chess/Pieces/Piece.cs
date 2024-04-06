using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

public abstract class Piece
{
    public Piece(Color color)
    {
        Color = color;
    }
    public abstract string Name { get; }

    public Color Color { get; set; }
    public abstract List<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate);
    public abstract IEnumerable<MoveCoordinate> MoveCoordinates();

}
