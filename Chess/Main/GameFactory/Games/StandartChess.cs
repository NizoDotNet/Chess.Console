
using Chess.Helpers;
using Chess.Pieces;

namespace Chess.Main.GameFactory.Games;

public class StandartChess : IGame
{
    private readonly IRenderer _renderer;
    public StandartChess(IRenderer renderer)
    {
        Board = new Board();
        _renderer = renderer;
    }

    public Board Board { get; set; }

    public IRenderer Renderer => _renderer;

    public void StartGame()
    {
        SetPieces();
        _renderer.Render(Board);
    }

    private void SetPieces()
    {
        SetPieces(Color.Black, 8);
        SetPieces(Color.White, 1);

    }

    private void SetPieces(Color color, int rank)
    {
        Board.PieceAndCoordinates[new Helpers.Coordinate { File = Helpers.File.A, Rank = rank}] = new Rook(color);
        Board.PieceAndCoordinates[new Helpers.Coordinate { File = Helpers.File.B, Rank = rank }] = new Knight(color);
        Board.PieceAndCoordinates[new Helpers.Coordinate { File = Helpers.File.C, Rank = rank }] = new Bishop(color);

        Board.PieceAndCoordinates[new Helpers.Coordinate { File = Helpers.File.D, Rank = rank }] = new Queen(color);
        Board.PieceAndCoordinates[new Helpers.Coordinate { File = Helpers.File.E, Rank = rank }] = new King(color);

        Board.PieceAndCoordinates[new Helpers.Coordinate { File = Helpers.File.F, Rank = rank }] = new Bishop(color);
        Board.PieceAndCoordinates[new Helpers.Coordinate { File = Helpers.File.G, Rank = rank }] = new Knight(color);
        Board.PieceAndCoordinates[new Helpers.Coordinate { File = Helpers.File.H, Rank = rank }] = new Rook(color);
        switch (color)
        {
            case Color.White:
                rank++;
                break;
            case Color.Black:
                rank--;
                break;
        }
        for(int i = 1; i <= 8; i++)
            Board.PieceAndCoordinates[new Helpers.Coordinate { File = (Helpers.File)i, Rank = rank }] = new Pawn(color);

        

    }
}
