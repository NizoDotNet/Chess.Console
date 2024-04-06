
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
            (Coordinate, Coordinate) move = _renderer.AskMove(color);

            if (Board.PieceAndCoordinates.TryGetValue(move.Item1, out Piece piece) && piece.Color == color)
            {
                var allowedMoves = piece.GetAllowedMoves(Board, move.Item1);
                if (!allowedMoves.Contains(move.Item2))
                {
                    _renderer.Error("You can't move this piece to this squere");
                }
                else
                {
                    Board.RemovePiece(move.Item1);
                    Board.RemovePiece(move.Item2);
                    if(piece.Name == "Pawn")
                    {
                        if (((Pawn)piece).CheckPromation(move.Item2)) 
                            piece = _renderer.Promation(piece.Color);
                    }
                        
                    Board.SetPiece(piece, move.Item2);
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
            else
            {
                _renderer.Error("You can't move this piece");
            }
                
            
            
        }
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
            Board.PieceAndCoordinates[new Coordinate { File = (Helpers.File)i, Rank = rank }] = new Pawn(color);



    }
}
