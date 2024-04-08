using Chess.Helpers;
using Chess.Main;
using Chess.Pieces.LongRangeMove;

namespace Chess.Pieces.Move;

public class DiagonalRight : ILongRangeMove
{
    public IEnumerable<Coordinate> Move(Coordinate coordinate, Board board, Color color)
    {
        int rank = coordinate.Rank;
        int file = (int)coordinate.File;

        int idx = 1;
        while (rank + idx < 9 && file + idx < 9)
        {

            if (board.PieceExist(rank + idx, (Helpers.File)(file + idx), out Piece piece, out Coordinate cr))
            {
                if (piece.Color != color) yield return cr;
                break;
            }
            yield return cr;
            idx++;
        }

        idx = 1;
        while (rank - idx > 0 && file + idx < 9)
        {

            if (board.PieceExist(rank - idx, (Helpers.File)(file + idx), out Piece piece, out Coordinate cr))
            {
                if (piece.Color != color) yield return cr;
                break;
            }
            yield return cr;
            idx++;
        }

    }
}
