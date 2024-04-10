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


    public override PieceType Type => PieceType.Rook;

    public override List<Coordinate> GetAllMoves(Board board, Coordinate coordinate)
    {
        return [.. horizantal.Move(coordinate, board, this.Color), .. vertical.Move(coordinate, board, this.Color)];
    }

    
}
