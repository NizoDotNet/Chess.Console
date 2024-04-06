using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

public class Knight : Piece
{
    public Knight(Color color) : base(color)
    {
    }
    public override string Name => nameof(Knight);

    public override List<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<MoveCoordinate>  MoveCoordinates()
    {
        yield break;
    }

}
