using Chess.Helpers;

namespace Chess.Pieces;

public abstract class Piece
{
    public Piece(Color color)
    {
        Color = color;
    }
    public abstract string Name { get; }

    public Color Color { get; set; }
    public abstract void PieceMoves();
}
