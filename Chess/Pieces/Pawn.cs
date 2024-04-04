using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

public class Pawn : Piece, IPawn
{
    public Pawn(Color color) : base(color)
    {
        isMoved = false;
    }

    public override string Name => nameof(Pawn);

    public bool isMoved { get; set; }

    public override IEnumerable<Coordinate> GetAllowedMoves(Board board, Coordinate coordinate)
    {
        var moveCoordinates = MoveCoordinates();
        foreach (var move in moveCoordinates)
        {
            Coordinate checkCoordinate = new(coordinate.Rank + move.Rank, coordinate.File);
            if (!board.PieceAndCoordinates.ContainsKey(checkCoordinate))
            {
                yield return checkCoordinate;
            }
        }
    }


    public override IEnumerable<MoveCoordinate>  MoveCoordinates()
    {
        if(!isMoved)
        {
            if(this.Color == Color.White)
                yield return new MoveCoordinate(2, 0);
            
            else 
                yield return new MoveCoordinate(-2, 0);
            isMoved = true;
        }
        if(this.Color == Color.White)
        {
            yield return new MoveCoordinate(1, 0);
        }
        else
        {
            yield return new MoveCoordinate(-1, 0);
        }
    }
}
