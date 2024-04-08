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

    
    public void SetPiece(Piece piece, Coordinate coordinate)
    {
        if(!PieceAndCoordinates.ContainsKey(coordinate))
            PieceAndCoordinates[coordinate] = piece;
        
    }

    public void RemovePiece(Coordinate coordinate)
    {
        if(PieceAndCoordinates.ContainsKey(coordinate))
        {
            PieceAndCoordinates.Remove(coordinate);
        }
    }

    public bool PieceExist(int rank, Helpers.File file, out Piece piece, out Coordinate coordinate)
    {
        coordinate = new(rank, file);
        return this.PieceAndCoordinates.TryGetValue(coordinate, out piece);
    }
    public bool IsSquereWhite(Coordinate coordinate) => ((int)coordinate.File + coordinate.Rank) % 2 != 0;
}