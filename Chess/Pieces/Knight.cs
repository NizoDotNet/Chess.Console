using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

public class Knight : Piece
{
    public Knight(Color color) : base(color)
    {
    }
    public override PieceType Type => PieceType.Knight;

    public override List<Coordinate> GetAllMoves(Board board, Coordinate coordinate)
    {
        var coordinates = new List<Coordinate>();
        var moveCoordinates = MoveCoordinates();
        foreach ( var move in moveCoordinates )
        {
            try
            {
                Coordinate checkCoordinate = new(coordinate.Rank + move.Rank, coordinate.File + move.File);
                if (!board.PieceAndCoordinates.TryGetValue(checkCoordinate, out Piece piece) 
                    || piece.Color != this.Color)
                {
                    coordinates.Add(checkCoordinate);
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                continue;
            }
        }
        return coordinates;
    }

    public IEnumerable<MoveCoordinate>  MoveCoordinates()
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
