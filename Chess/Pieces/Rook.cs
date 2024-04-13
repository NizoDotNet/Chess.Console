using Chess.Helpers;
using Chess.Main;
using Chess.Pieces.LongRangeMove;

namespace Chess.Pieces;

public class Rook : Piece
{
    private readonly ILongRangeMove horizantal;
    private readonly ILongRangeMove vertical;
    private bool isMoved = false;
    public Rook(Color color) : base(color)
    {
        horizantal = new Horizantal();
        vertical = new Vertical();
    }

    public bool IsMoved => isMoved;

    public override PieceType Type => PieceType.Rook;

    public override IEnumerable<Coordinate> GetAllMoves(Board board, Coordinate coordinate)
    {
        return [.. horizantal.Move(coordinate, board, this.Color), .. vertical.Move(coordinate, board, this.Color)];
    }

    public override void MakeMove(Board board, Coordinate from, Coordinate to)
    {
        base.MakeMove(board, from, to);
        isMoved = true;
    }
}
