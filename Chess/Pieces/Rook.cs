using Chess.Helpers;

namespace Chess.Pieces;

public class Rook : Piece
{
    public Rook(Color color) : base(color)
    {
    }

    public override string Name => nameof(Rook);

    public override void PieceMoves()
    {
        throw new NotImplementedException();
    }
}
