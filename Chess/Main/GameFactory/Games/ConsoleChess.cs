using Chess.Helpers;
using Chess.Pieces;

namespace Chess.Main.GameFactory.Games;


public class ConsoleChess : IGame
{
    private readonly IRenderer _renderer;
    private Color color;
    public ConsoleChess(IRenderer renderer)
    {
        Board = new Board();
        _renderer = renderer;
        color = Color.White;
    }

    public Board Board { get; set; }

    public List<string> Moves = new();
    public void StartGame(string? fen = null)
    {
        
        SetPieces(fen, _renderer.Promation);
        Moves.Add(Board.GetFen());
        while (true)
        {
            _renderer.Render(Board);
            if (Board.IsKingFrightened(color))
            {
                if(Board.GetAllowedMovesCount(color) == 0)
                {
                    _renderer.Error("Checkmate!!!");
                    break;
                }
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

    public void SetPieces(string? fen, Promation promation)
    {
        Board.SetFen(fen ?? "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR", promation);
    } 

}
