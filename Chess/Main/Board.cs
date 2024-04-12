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

    public void SetFen(string fen, Promation promation)
    {
        string[] rows = fen.Split("/");
        for(int i = 0; i < rows.Length; i++)
        {
            Helpers.File file = (Helpers.File)1;
            for(int j = 0; j < rows[i].Length; j++)
            {
                char c = rows[i][j];
                if (!char.IsDigit(c))
                {
                    var piece = GetPieceByLetter(c, promation);
                    SetPiece(piece, new(8- i, file));
                    file = j == (rows[i].Length - 1) ? file : file + 1;

                }
                else file = j == (rows[i].Length - 1) ? file : file + (c - '0');
            }
        }
    }

    private Piece GetPieceByLetter(char letter, Promation promation)
    {
        Color color = char.IsLower(letter) ? Color.Black : Color.White;
        letter = char.ToLower(letter);
        return letter switch
        {
            'k' => new King(color),
            'q' => new Queen(color),
            'b' => new Bishop(color),
            'n' => new Knight(color),
            'r' => new Rook(color),
            'p' => new Pawn(color, promation)
        };
    }

    public void SetPiece(Piece piece, Coordinate coordinate)
    {
       PieceAndCoordinates[coordinate] = piece; 
    }

    public Piece RemovePiece(Coordinate coordinate)
    {
        if(PieceAndCoordinates.TryGetValue(coordinate, out Piece piece))
        {
            PieceAndCoordinates.Remove(coordinate);
            return piece;
        }
        return null;
    }

    public bool PieceExist(int rank, Helpers.File file, out Piece piece, out Coordinate coordinate)
    {
        coordinate = new(rank, file);
        return this.PieceAndCoordinates.TryGetValue(coordinate, out piece);
    }
    public bool IsSquereWhite(Coordinate coordinate) => ((int)coordinate.File + coordinate.Rank) % 2 != 0;

    public Coordinate GetKing(Color color) => 
        this.PieceAndCoordinates
            .Where(c => c.Value.Type == PieceType.King && c.Value.Color == color)
            .First()
            .Key;
    public IEnumerable<Coordinate> GetAllMoves(Color color)
    {
        return this.PieceAndCoordinates
            .Where(c => c.Value.Color == color)
            .SelectMany(c => c.Value.GetAllMoves(this, c.Key));
    }

    public bool IsKingFrightened(Color color)
    {
        var kingCoordinate = this.GetKing(color);
        color = color == Color.White ? Color.Black : Color.White;
        var opMoves = GetAllMoves(color);
        return opMoves.Contains(kingCoordinate);
    }

    public int GetAllowedMovesCount()
    {
        return PieceAndCoordinates
            .SelectMany(c => c.Value.GetAllowedMoves(this, c.Key))
            .Count();
    }
}