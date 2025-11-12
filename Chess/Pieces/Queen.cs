using Chess.Helpers;
using Chess.Main;
using Chess.Pieces.LongRangeMove;
using Chess.Pieces.Move;

namespace Chess.Pieces;

public class Queen : Piece
{
    private readonly ILongRangeMove horizantal, vertical, diagonalLeft, diagonalRight;
    public Queen(Color color) : base(color)
    {
        horizantal = new Vertical();
        vertical = new Horizontal();
        diagonalLeft = new DiagonalLeft();
        diagonalRight = new DiagonalRight();    

    }

    public override PieceType Type => PieceType.Queen;

    public override IEnumerable<Coordinate> GetAllMoves(Board board, Coordinate coordinate)
    {
        
        return [.. horizantal.Move(coordinate, board, Color), 
            ..vertical.Move(coordinate, board, Color), 
            ..diagonalLeft.Move(coordinate, board, Color), 
            ..diagonalRight.Move(coordinate, board, Color)];
    }


}
