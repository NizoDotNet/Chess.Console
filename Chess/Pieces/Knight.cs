using Chess.Helpers;

namespace Chess.Pieces;

public class Knight : Piece
{
    public Knight(Color color) : base(color)
    {
    }
    public override string Name => nameof(Knight);

    public override void PieceMoves()
    {
        throw new NotImplementedException();
    }
}
