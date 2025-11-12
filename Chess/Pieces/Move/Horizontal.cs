using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces.LongRangeMove;

public class Horizontal : ILongRangeMove
{
    public IEnumerable<Coordinate> Move(Coordinate coordinate, Board board, Color color)
    {
        int rank = coordinate.Rank;

        for (int i = (int)coordinate.File - 1; i >= 1; i--)
        {
            var cr = new Coordinate(rank, (Helpers.File)i);

            if (board.PieceExist(rank, (Helpers.File)i, out Piece piece, out _))
            {
                if (piece.Color != color)
                    yield return cr;
                break;
            }

            yield return cr;
        }

        for (int i = (int)coordinate.File + 1; i <= 8; i++)
        {
            var cr = new Coordinate(rank, (Helpers.File)i);

            if (board.PieceExist(rank, (Helpers.File)i, out Piece piece, out _))
            {
                if (piece.Color != color)
                    yield return cr;
                break;
            }

            yield return cr;
        }
    }
}
