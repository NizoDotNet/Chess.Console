using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces.LongRangeMove;

public class Vertical : ILongRangeMove
{
    public IEnumerable<Coordinate> Move(Coordinate coordinate, Board board, Color color)
    {
        Helpers.File file = coordinate.File;

        for (int i = coordinate.Rank - 1; i >= 1; i--)
        {
            var cr = new Coordinate(i, file);

            if (board.PieceExist(i, file, out Piece piece, out cr))
            {
                if (piece.Color != color) yield return cr;
                break;
            }
            yield return cr;
        }

        for(int i = coordinate.Rank + 1; i <= 8; i++)
        {
            var cr = new Coordinate(i, file);

            if (board.PieceExist(i, file, out Piece piece, out cr))
            {
                if (piece.Color != color) yield return cr;
                break;
            }
            yield return cr;
        }

    }
}
