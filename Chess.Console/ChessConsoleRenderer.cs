using Chess.Helpers;
using Chess.Main;
using Chess.Pieces;
using static System.Console;
namespace Chess.Console;

public class ChessConsoleRenderer : IRenderer
{

    public ChessConsoleRenderer()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;

    }
    public void Render(Board board)
    {
        System.Console.Clear();
        ConsoleColor backColor = System.Console.BackgroundColor;
        ConsoleColor forColor = System.Console.ForegroundColor;
        SetCursorPosition(0, 0);
        for (int i = 8; i >= 1; i--)
        {
            if (i == 1)
            {
                Write($"{i}");
                break;
            }
            WriteLine(i);
        }
        
        for (int i = 8; i >= 1; i--)
        {
            SetCursorPosition(1, 8-i);
            for (int j = 1; j <= 8; j++)
            {
                Coordinate coordinate = new Helpers.Coordinate { File = (Helpers.File)j, Rank = i };
                System.Console.BackgroundColor = GetSquereColor(coordinate, board);

                if (board.PieceAndCoordinates.TryGetValue(coordinate, out Piece piece))
                {
                    System.Console.ForegroundColor = GetPieceColor(piece);
                    System.Console.Write($" {GetPiece(piece.Type)} ");
                    System.Console.ForegroundColor = forColor;
                }
                else System.Console.Write("   ");
                System.Console.BackgroundColor = backColor;
            }
            WriteLine();
        }
        for (int i = 1; i <= 8; i++)
        {
            Write($" {(Helpers.File)i} ");
        }
        WriteLine();
    }

    private ConsoleColor GetSquereColor(Coordinate coordinate, Board board)
    {
        if (board.IsSquereWhite(coordinate)) return ConsoleColor.DarkYellow;
        return ConsoleColor.Red;
    }

    private ConsoleColor GetPieceColor(Piece piece)
    {
        if (piece.Color == Color.White) return ConsoleColor.White;
        return ConsoleColor.Black;
    }
    private string GetPiece(PieceType pieceType)
    {
        return pieceType switch
        {
            PieceType.King => "♔",
            PieceType.Queen => "♕",
            PieceType.Rook => "♖",
            PieceType.Bishop => "♗",
            PieceType.Knight => "♘",
            PieceType.Pawn => "♙",
            _ => ""
        };
    }

    public void Error(string message)
    {
        ConsoleColor curColor = System.Console.ForegroundColor;
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine(message);
        System.Console.ForegroundColor = curColor;
        System.Console.ReadKey();

    }

    public Piece Promation(Color color)
    {
        System.Console.WriteLine("1. Queen");
        System.Console.WriteLine("2. Bishop");
        System.Console.WriteLine("3. Knight");
        System.Console.WriteLine("4. Rook");
        int pieceNo = int.Parse(System.Console.ReadLine());

        return pieceNo switch
        {
            1 => new Queen(color),
            2 => new Bishop(color),
            3 => new Knight(color),
            4 => new Rook(color),
            _ => throw new Exception("???")
        };
    }

    Coordinate IRenderer.AskMove(Color color, Board board)
    {
        while (true)
        {
            WriteLine("Choose Piece");
            for (int i = 1; i <= 8; i++)
            {
                System.Console.Write($"{i}.{(Helpers.File)i} ");
            }
            System.Console.WriteLine();
            int fromFileInt = int.Parse(ReadLine());
            Helpers.File fromFile = (Helpers.File)fromFileInt;
            int fromRankInt = int.Parse(ReadLine());
            Coordinate from = new Coordinate { File = fromFile, Rank = fromRankInt };
            if (board.PieceAndCoordinates.TryGetValue(from, out var piece) && piece.Color == color)
                return from;
            else
                WriteLine("There is no piece in this coordinate");
        }
    }

    public Coordinate ShowAvaibleMoves(IList<Coordinate> coordinates)
    {
        while (true)
        {
            for (int i = 1; i <= coordinates.Count; i++)
                WriteLine($"{i}. {coordinates[i-1]}");
            if (int.TryParse(ReadLine(), out int moveindex) && moveindex - 1 <= coordinates.Count)
                return coordinates[moveindex-1];
        }
        
    }

    public void IsCheck()
    {
        throw new NotImplementedException();
    }
}
