using Chess.Helpers;

namespace Chess.Pieces;

public class Pawn : Piece
{
    public Pawn(Color color) : base(color)
    {
    }

    public override string Name => nameof(Pawn);

    public override void PieceMoves()
    {
        throw new NotImplementedException();
    }
}
