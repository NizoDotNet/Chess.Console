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
        board.EnPassant = null;
        board.RemovePiece(to);
        board.RemovePiece(from);
        board.SetPiece(this, to);
    }

    protected bool KingCheck(Board board, Coordinate from, Coordinate to)
    {
        var p1 = CheckMoveStepOne(board, from, to);
        var res = board.IsKingFrightened(this.Color);
        CheckMoveStepTwo(p1, board, from, to);
        return res;
    }

    public Piece CheckMoveStepOne(Board board, Coordinate from, Coordinate to)
    {
        var p1 = board.RemovePiece(to);
        var p2 = board.RemovePiece(from);
        board.SetPiece(p2, to);
        return p1;
    }

    public void CheckMoveStepTwo(Piece piece, Board board, Coordinate from, Coordinate to)
    {
        var p1 = board.RemovePiece(to);
        board.SetPiece(p1, from);
        if(piece is not null) board.SetPiece(piece, to);
    }

}
