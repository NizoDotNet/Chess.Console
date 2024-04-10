
using Chess.Helpers;
using Chess.Pieces;

namespace Chess.Main.GameFactory.Games;


public class StandartChess : IGame
{
    private readonly IRenderer _renderer;
    private Color color;
    public StandartChess(IRenderer renderer)
    {
        Board = new Board();
        _renderer = renderer;
        color = Color.White;
    }

    public Board Board { get; set; }

    public IRenderer Renderer => _renderer;

    public void StartGame()
    {
        SetPieces();
        
        while (true)
        {
            _renderer.Render(Board);
            if (IsKingFrightened(color))
            {
                _renderer.Error("Your king is under attack");
            }
            Coordinate coordinate = _renderer.AskMove(color, Board);
            var piece = Board.PieceAndCoordinates[coordinate];
            var allowedMoves = piece.GetAllowedMoves(Board, coordinate);

            if(allowedMoves.Count == 0)
            {
                _renderer.Error("You can't move this piece");
                continue;
            } 
                
            var moveTo = _renderer.ShowAvaibleMoves(allowedMoves);
            piece.MakeMove(Board, coordinate, moveTo);
            if(IsKingFrightened(color))
            {
                piece.MakeMove(Board, moveTo, coordinate);
                _renderer.Error("Your king is under attack");
                continue;
            }
            switch (color)
            {
                case Color.White:
                    color = Color.Black;
                    break;
                default:
                    color = Color.White;
                    break;
            }            
        }
    }

    private IEnumerable<Coordinate> GetAllMoves(Color color)
    {
        return Board.PieceAndCoordinates
            .Where(c => c.Value.Color == color)
            .SelectMany(c => c.Value.GetAllowedMoves(Board, c.Key));
    }
    private bool IsKingFrightened(Color color)
    {
        var kingCoordinate = Board.PieceAndCoordinates
            .Where(c => c.Value.Type == PieceType.King && c.Value.Color == color)
            .First()
            .Key;
        color = color == Color.White ? Color.Black : Color.White;
        var opMoves = GetAllMoves(color)
            .ToHashSet();
        if (opMoves.Contains(kingCoordinate))
        {
            return true;
        }
        return false;
    }
    private void SetPieces()
    {
        SetPieces(Color.Black, 8);
        SetPieces(Color.White, 1);

    }

    private void SetPieces(Color color, int rank)
    {
        Board.PieceAndCoordinates[new Coordinate { File = Helpers.File.A, Rank = rank }] = new Rook(color);
        Board.PieceAndCoordinates[new Coordinate { File = Helpers.File.B, Rank = rank }] = new Knight(color);
        Board.PieceAndCoordinates[new Coordinate { File = Helpers.File.C, Rank = rank }] = new Bishop(color);

        Board.PieceAndCoordinates[new Coordinate { File = Helpers.File.D, Rank = rank }] = new Queen(color);
        Board.PieceAndCoordinates[new Coordinate { File = Helpers.File.E, Rank = rank }] = new King(color);

        Board.PieceAndCoordinates[new Coordinate { File = Helpers.File.F, Rank = rank }] = new Bishop(color);
        Board.PieceAndCoordinates[new Coordinate { File = Helpers.File.G, Rank = rank }] = new Knight(color);
        Board.PieceAndCoordinates[new Coordinate { File = Helpers.File.H, Rank = rank }] = new Rook(color);
        switch (color)
        {
            case Color.White:
                rank++;
                break;
            case Color.Black:
                rank--;
                break;
        }
        for (int i = 1; i <= 8; i++)
            Board.PieceAndCoordinates[new Coordinate { File = (Helpers.File)i, Rank = rank }] = new Pawn(color, _renderer.Promation);



    }
}
