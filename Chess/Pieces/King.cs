using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

internal class King : Piece
{
    public King(Color color) : base(color)
    {
    }

    public override PieceType Type => PieceType.King;

    public override List<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate)
    {
        return [];
    }
    public IEnumerable<MoveCoordinate> MoveCoordinates()
    {
        yield return new MoveCoordinate(1, 0);
        yield return new MoveCoordinate(-1, 0);
        yield return new MoveCoordinate(0, 1);
        yield return new MoveCoordinate(0, -1);
        yield return new MoveCoordinate(1, 1);
        yield return new MoveCoordinate(1, -1);
        yield return new MoveCoordinate(-1, 1);
        yield return new MoveCoordinate(-1, -1);
    }

}
