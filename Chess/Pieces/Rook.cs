using Chess.Helpers;
using Chess.Main;
using Chess.Pieces.LongRangeMove;

namespace Chess.Pieces;

public class Rook : Piece
{
    private readonly ILongRangeMove horizantal;
    private readonly ILongRangeMove vertical;   
    public Rook(Color color) : base(color)
    {
        horizantal = new Horizantal();
        vertical = new Vertical();
    }

    public override string Name => nameof(Rook);

    public override List<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate)
    {
        List<Coordinate> allowedMoves = [.. horizantal.Move(coordinate, board, this.Color), .. vertical.Move(coordinate, board, this.Color)];
        return allowedMoves;
    }

    public override IEnumerable<MoveCoordinate>  MoveCoordinates()
    {
        yield break;
    }
}
