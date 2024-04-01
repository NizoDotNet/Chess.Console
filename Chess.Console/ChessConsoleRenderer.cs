using Chess.Helpers;
using Chess.Main;
using Chess.Pieces;

namespace Chess.Console;

public class ChessConsoleRenderer : IRenderer
{

    public ChessConsoleRenderer()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;

    }
    public void Render(Board board)
    {
        ConsoleColor backColor = System.Console.BackgroundColor;
        ConsoleColor forColor = System.Console.ForegroundColor;

        for (int i = 8;i >= 1; i--)
        {
            for(int j = 1;j <= 8; j++) 
            {
                Coordinate coordinate = new Helpers.Coordinate { File = (Helpers.File)j, Rank = i };
                System.Console.BackgroundColor = GetSquereColor(coordinate, board);

                if (board.PieceAndCoordinates.TryGetValue(coordinate, out Piece piece))
                {
                    System.Console.ForegroundColor = GetPieceColor(piece);
                    System.Console.Write($" {GetPiece(piece.Name)} ");
                    System.Console.ForegroundColor = forColor;
                }
                else System.Console.Write("   ");
                System.Console.BackgroundColor = backColor;
            }
            System.Console.WriteLine();
        }
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
    private string GetPiece(string pieceName)
    {
        return pieceName switch 
        {
            "King" => "♔",
            "Queen" => "♕",
            "Rook" => "♖",
            "Bishop" => "♗",
            "Knight" => "♘",
            "Pawn" => "♙",
            _ => ""
        };
    }

    public (Coordinate, Coordinate) AskMove(Color color)
    {
        try
        {
            System.Console.WriteLine("From: ");
            for (int i = 1; i <= 8; i++)
            {
                System.Console.Write($"{i}.{(Helpers.File)i} ");
            }
            System.Console.WriteLine();
            int fromFileInt = int.Parse(System.Console.ReadLine());
            Helpers.File fromFile = (Helpers.File)fromFileInt;
            int fromRankInt = int.Parse(System.Console.ReadLine());
            Coordinate from = new Coordinate { File = fromFile, Rank = fromRankInt };

            System.Console.WriteLine("To: ");
            for (int i = 1; i <= 8; i++)
            {
                System.Console.Write($"{i}.{(Helpers.File)i} ");
            }
            System.Console.WriteLine();
            int toFileInt = int.Parse(System.Console.ReadLine());
            Helpers.File toFile = (Helpers.File)toFileInt;
            int toRankInt = int.Parse(System.Console.ReadLine());

            Coordinate to = new Coordinate { Rank = toRankInt, File = toFile };
            return (from, to);

        }
        catch (Exception ex)
        {
            Error(ex.ToString());
            return (null, null);
        }
    }

    public void Error(string message)
    {
        ConsoleColor curColor = System.Console.ForegroundColor;
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine(message);
        System.Console.ForegroundColor = curColor;

    }
}
