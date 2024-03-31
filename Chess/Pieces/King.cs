using Chess.Helpers;

namespace Chess.Pieces;

internal class King : Piece
{
    public King(Color color) : base(color)
    {
    }
    public override string Name => nameof(King);

    public override void PieceMoves()
    {
        throw new NotImplementedException();
    }
}
