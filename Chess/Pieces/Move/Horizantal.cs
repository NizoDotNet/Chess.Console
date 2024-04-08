using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces.LongRangeMove;

public class Horizantal : ILongRangeMove
{
    public List<Coordinate> Move(Coordinate coordinate, Board board, Color color)
    {
        var res = new List<Coordinate>();
        Helpers.File file = coordinate.File;

        for (int i = coordinate.Rank - 1; i >= 1; i--)
        {
            if (board.PieceExist(i, file, out Piece piece))
            {
                if (piece.Color != color) res.Add(new(i, file));
                break;
            }
            res.Add(new(i, file));
        }

        for(int i = coordinate.Rank + 1; i <= 8; i++)
        {
            if(board.PieceExist(i, file, out Piece piece))
            {
                if (piece.Color != color) res.Add(new(i, file));
                break;
            }
            res.Add(new(i, file));
        }

        return res;
    }
}
