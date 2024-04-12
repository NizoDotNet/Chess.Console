using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

internal class King : Piece
{
    public King(Color color) : base(color)
    {
    }

    public override PieceType Type => PieceType.King;

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

}
