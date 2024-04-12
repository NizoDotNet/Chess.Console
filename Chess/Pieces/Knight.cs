using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

public class Knight : Piece
{
    public Knight(Color color) : base(color)
    {
    }
    public override PieceType Type => PieceType.Knight;

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
        yield return new MoveCoordinate(2, -1);
        yield return new MoveCoordinate(2, 1);
        yield return new MoveCoordinate(-2, -1);
        yield return new MoveCoordinate(-2, 1);
        yield return new MoveCoordinate(1, -2);
        yield return new MoveCoordinate(1, 2);
        yield return new MoveCoordinate(-1, 2);
        yield return new MoveCoordinate(-1, -2);
    }

}
