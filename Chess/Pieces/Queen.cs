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
        horizantal = new Horizantal();
        vertical = new Vertical();
        diagonalLeft = new DiagonalLeft();
        diagonalRight = new DiagonalRight();    

    }
    public override string Name => nameof(Queen);

    public override List<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate)
    {
        
        return [.. horizantal.Move(coordinate, board, Color), 
            ..vertical.Move(coordinate, board, Color), 
            ..diagonalLeft.Move(coordinate, board, Color), 
            ..diagonalRight.Move(coordinate, board, Color)];
    }


}
