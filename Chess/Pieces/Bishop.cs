using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Color color) : base(color)
        {
        }
        public override string Name => nameof(Bishop);

        public override IEnumerable<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<MoveCoordinate>  MoveCoordinates()
        {
            yield break;
        }

    }
}
