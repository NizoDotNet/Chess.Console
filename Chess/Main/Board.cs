using Chess.Helpers;
using Chess.Pieces;

namespace Chess.Main;

public class Board
{
    public Dictionary<Coordinate, Piece> PieceAndCoordinates { get; set; }
    public Board()
    {
        PieceAndCoordinates = new();
    }

    

    public bool IsSquereWhite(Coordinate coordinate) => ((int)coordinate.File + coordinate.Rank) % 2 != 0;
}