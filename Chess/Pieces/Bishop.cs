using Chess.Helpers;

namespace Chess.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(Color color) : base(color)
        {
        }
        public override string Name => nameof(Bishop);


        public override void PieceMoves()
        {
            throw new NotImplementedException();
        }
    }
}
