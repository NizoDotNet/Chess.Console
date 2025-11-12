using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces.LongRangeMove;

public class Horizontal : ILongRangeMove
{
    public IEnumerable<Coordinate> Move(Coordinate coordinate, Board board, Color color)
    {
        int rank  = coordinate.Rank;

        for (int i = (int)coordinate.File - 1; i >= 1; i--)
        {
            if (board.PieceExist(rank, (Helpers.File)i, out Piece piece, out Coordinate cr))
            {
                if (piece.Color != color) yield return cr;
                break;
            }
            yield return cr;
        }

        for (int i = (int) coordinate.File + 1; i <= 8; i++)
        {
            if (board.PieceExist(rank, (Helpers.File)i, out Piece piece, out Coordinate cr))
            {
                if (piece.Color != color) yield return cr;
                break;
            }
            yield return cr;
        }

    }
}
