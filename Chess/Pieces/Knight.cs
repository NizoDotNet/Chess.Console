using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

public class Knight : Piece
{
    public Knight(Color color) : base(color)
    {
    }
    public override string Name => nameof(Knight);

    public override List<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate)
    {
        var res = new List<Coordinate>();
        var moveCoordinates = MoveCoordinates();
        foreach ( var move in moveCoordinates )
        {
            try
            {
                Coordinate checkCoordinate = new(coordinate.Rank + move.Rank, coordinate.File + move.File);
                res.Add(checkCoordinate);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                continue;
            }
        }
        return res;
    }

    public override IEnumerable<MoveCoordinate>  MoveCoordinates()
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
