using Chess.Helpers;

namespace Chess.Pieces;

public class Queen : Piece
{
    public Queen(Color color) : base(color)
    {
    }
    public override string Name => nameof(Queen);

    public override void PieceMoves()
    {
        throw new NotImplementedException();
    }
}
