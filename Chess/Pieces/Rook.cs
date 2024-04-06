using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

public class Rook : Piece
{
    public Rook(Color color) : base(color)
    {
    }

    public override string Name => nameof(Rook);

    public override List<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<MoveCoordinate>  MoveCoordinates()
    {
        yield break;
    }
}
