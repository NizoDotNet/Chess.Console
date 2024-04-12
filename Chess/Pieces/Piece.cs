using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

public abstract class Piece
{
    public Piece(Color color)
    {
        Color = color;
    }
    public abstract PieceType Type { get; }
    public Color Color { get; set; }
    public abstract IEnumerable<Coordinate> GetAllMoves(Board board, Coordinate coordinate);
    public virtual List<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate)
    {
        return GetAllMoves(board, coordinate)
            .Where(c => !KingCheck(board, coordinate, c))
            .ToList();
    }


    public virtual void MakeMove(Board board, Coordinate from, Coordinate to)
    {
        board.RemovePiece(to);
        board.RemovePiece(from);
        board.SetPiece(this, to);
    }

    protected bool KingCheck(Board board, Coordinate from, Coordinate to)
    {
        var p1 = CheckMove(this, board, from, to);
        var res = board.IsKingFrightened(this.Color);
        CheckMove(p1, board, to, from);
        return res;
    }

    public Piece CheckMove(Piece piece, Board board, Coordinate from, Coordinate to)
    {
        var p1 = board.RemovePiece(to);
        board.RemovePiece(from);
        if(piece != null) board.SetPiece(piece, to);
        return p1;
    }

}
