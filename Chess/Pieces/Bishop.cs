using Chess.Helpers;
using Chess.Main;
using Chess.Pieces.LongRangeMove;
using Chess.Pieces.Move;

namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        private readonly ILongRangeMove diagonalLeft;
        private readonly ILongRangeMove diagonalRight;

        public Bishop(Color color) : base(color)
        {
            diagonalLeft = new DiagonalLeft();
            diagonalRight = new DiagonalRight();

        }

        public override PieceType Type => PieceType.Bishop;

        public override List<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate)
        {
            return [.. diagonalLeft.Move(coordinate, board, this.Color), ..diagonalRight.Move(coordinate, board, this.Color)];
        }


    }
}
