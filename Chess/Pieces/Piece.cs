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
    public abstract IEnumerable<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate);
    public IEnumerable<Coordinate> AllowedCoordinates { get; set; }
    public abstract IEnumerable<MoveCoordinate> MoveCoordinates();

}
