using Chess.Helpers;
using Chess.Main;
using System.ComponentModel.Design;

namespace Chess.Pieces;

internal class King : Piece
{
    public King(Color color) : base(color)
    {
    }

    public override PieceType Type => PieceType.King;
    private bool isMoved = false;

    public IEnumerable<Coordinate> Castling(Board board)
    {
        if(IsCastlingPossible(board, Helpers.File.A))
        {
            if (Color == Color.White)
                if(!board.PieceAndCoordinates.ContainsKey(new(1, Helpers.File.B))
                && !board.PieceAndCoordinates.ContainsKey(new(1, Helpers.File.C))
                && !board.PieceAndCoordinates.ContainsKey(new(1, Helpers.File.D)))
                    yield return new(1,  Helpers.File.C);
            
            else
                if(!board.PieceAndCoordinates.ContainsKey(new(8, Helpers.File.B))
                && !board.PieceAndCoordinates.ContainsKey(new(8, Helpers.File.C))
                && !board.PieceAndCoordinates.ContainsKey(new(8, Helpers.File.D)))
                    yield return new(8, Helpers.File.C);
            
        }
        if(IsCastlingPossible(board, Helpers.File.H))
        {
            if(Color == Color.White)
                if (!board.PieceAndCoordinates.ContainsKey(new(1, Helpers.File.F))
                && !board.PieceAndCoordinates.ContainsKey(new(1, Helpers.File.G)))
                    yield return new(1, Helpers.File.G);
            else
                if (!board.PieceAndCoordinates.ContainsKey(new(8, Helpers.File.F))
                && !board.PieceAndCoordinates.ContainsKey(new(8, Helpers.File.G)))
                    yield return new(8, Helpers.File.G);
        }
    }

    public bool IsMoved => isMoved;
    public override IEnumerable<Coordinate> GetAllMoves(Board board, Coordinate coordinate)
    {
        var moveCoordinates = MoveCoordinates();
        foreach (var move in moveCoordinates)
        {
            int rank = coordinate.Rank + move.Rank;
            Helpers.File file = coordinate.File + move.File;
            if (rank <= 8 && rank >= 1 && (int)file <= 8 && (int)file >= 1)
            {
                Coordinate checkCoordinate = new(rank, file);
                if (!board.PieceAndCoordinates.TryGetValue(checkCoordinate, out Piece piece)
                    || piece.Color != this.Color)
                {
                    yield return checkCoordinate;
                }
            }
        }
        foreach (var move in Castling(board))
        {
            yield return move;
        }
    }
    public IEnumerable<MoveCoordinate> MoveCoordinates()
    {
        yield return new MoveCoordinate(1, 0);
        yield return new MoveCoordinate(-1, 0);
        yield return new MoveCoordinate(0, 1);
        yield return new MoveCoordinate(0, -1);
        yield return new MoveCoordinate(1, 1);
        yield return new MoveCoordinate(1, -1);
        yield return new MoveCoordinate(-1, 1);
        yield return new MoveCoordinate(-1, -1);
    }

    public override void MakeMove(Board board, Coordinate from, Coordinate to)
    {
        if(!isMoved && to.File == Helpers.File.G)
        {
            board.RemovePiece(from);
            board.SetPiece(this, to);
            var piece = board.RemovePiece(new(from.Rank, Helpers.File.H));
            board.SetPiece(piece, new(from.Rank, Helpers.File.F));
        }
        else if(!IsMoved && to.File == Helpers.File.C)
        {
            board.RemovePiece(from);
            board.SetPiece(this, to);
            var piece = board.RemovePiece(new(from.Rank, Helpers.File.A));
            board.SetPiece(piece, new(from.Rank, Helpers.File.C));
        }
        else
        {
            base.MakeMove(board, from, to);
        }
        isMoved = true;
    }

    private bool IsCastlingPossible(Board board, Helpers.File file)
    {
        int rank = Color == Color.White ? 1 : 8;
        Coordinate coordinate = new(rank, file);
        if (board.PieceAndCoordinates.TryGetValue(coordinate, out var piece)
            && piece is Rook
            && !((Rook)piece).IsMoved
            && !this.IsMoved
            )
            return true;
        return false;
    }
}
