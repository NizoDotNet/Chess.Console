using Chess.Helpers;
using Chess.Pieces;
using System.Text;

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
        PieceAndCoordinates = [];
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
    private char GetPieceLetter(PieceType pieceType, Color color)
    {
        char piece = pieceType switch
        {
            PieceType.King => 'k',
            PieceType.Queen => 'q',
            PieceType.Bishop => 'b',
            PieceType.Knight => 'k',
            PieceType.Rook => 'r',
            PieceType.Pawn => 'p'
        };

        if(color  == Color.White)
            piece = char.ToUpper(piece);
        return piece;
        
    }
    public void SetPiece(Piece piece, Coordinate coordinate)
    {
       PieceAndCoordinates[coordinate] = piece; 
    }
    public string GetFen()
    {
        StringBuilder fen = new();
        Coordinate coordinate = new();
        for (int i = 8; i >= 1; i--)
        {
            int rank = i;
            coordinate.Rank = rank;
            int empty = 0;
            for(int j = 1; j <= 8; j++)
            {
                var file = (Helpers.File)j;
                coordinate.File = file;
                if(PieceAndCoordinates.TryGetValue(coordinate, out var piece))
                {
                    var letter = GetPieceLetter(piece.Type, piece.Color);
                    if(empty == 0) fen.Append(letter);
                    else fen.Append($"{empty}{letter}");
                    empty = 0;
                }
                else
                {
                    empty++;
                }
            }
            if (empty != 0) fen.Append(empty);
            fen.Append('/');
        }
        return fen.ToString();
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

    public int GetAllowedMovesCount(Color color)
    {
        int count = 0;
        var clone = this.PieceAndCoordinates.Where(c => c.Value.Color == color).ToDictionary();
        foreach(var p in clone)
        {
            count += p.Value.GetAllowedMoves(this, p.Key).Count;
        }
        return count;
    }

}