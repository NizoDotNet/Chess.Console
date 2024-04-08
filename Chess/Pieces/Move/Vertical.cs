using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces.LongRangeMove;

public class Vertical : ILongRangeMove
{
    public List<Coordinate> Move(Coordinate coordinate, Board board, Color color)
    {
        var res = new List<Coordinate>();
        int rank  = coordinate.Rank;

        for (int i = (int)coordinate.File - 1; i >= 1; i--)
        {
            if (board.PieceExist(rank, (Helpers.File)i, out Piece piece))
            {
                if (piece.Color != color) res.Add(new(rank, (Helpers.File)i));
                break;
            }
            res.Add(new(rank, (Helpers.File)i));
        }

        for (int i = (int) coordinate.File + 1; i <= 8; i++)
        {
            if (board.PieceExist(rank, (Helpers.File)rank, out Piece piece))
            {
                if (piece.Color != color) res.Add(new(rank, (Helpers.File)i));
                break;
            }
            res.Add(new(rank, (Helpers.File)i));
        }

        return res;
    }
}
