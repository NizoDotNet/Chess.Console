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
        
        SetPieces(_renderer.Promation);
        
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

    private void SetPieces(Promation promation)
    {
        Board.SetFen("rnbqk2r/pppp1ppp/7n/2b1p2Q/2B1P3/8/PPPP1PPP/RNB1K1NR", promation);

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
