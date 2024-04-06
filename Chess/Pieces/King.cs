using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

internal class King : Piece
{
    public King(Color color) : base(color)
    {
    }
    public override string Name => nameof(King);

    public override List<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<MoveCoordinate>  MoveCoordinates()
    {
        yield break;
    }

}
