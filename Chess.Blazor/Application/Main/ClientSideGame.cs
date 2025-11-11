using Chess.Helpers;
using Chess.Main;
using Chess.Pieces;

namespace Chess.Blazor.Application.Main;


public class GameState
{
    public Color ColorTurn { get; private set; }
    public State State { get; private set; }
    public GameState()
    {
        ColorTurn = Color.White;
        State = State.None;
    }

    public void ChangeColor()
    {
        switch(ColorTurn)
        {
            case Color.White:
                ColorTurn = Color.Black;
                break;
            case Color.Black:
                ColorTurn = Color.White;
                break;
        }
    }
    
    public void ChangeState(State state)
    {
        State = state;
    }
}

public sealed class ClientSideGame
{
    public event Action OnPiecedMoved;
    public event Action OnMate;
    public event Action OnCheck;
    public ClientSideGame(string? fen)
    {
        Board = new();
        Board.SetFen(fen ?? "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR", null);
        State = new();
        OnPiecedMoved += State.ChangeColor;
        OnPiecedMoved += CheckKing;
        OnMate += () => State.ChangeState(Helpers.State.Mate);
        OnCheck += () => State.ChangeState(Helpers.State.Check);
   
    }
    public Board Board { get; set; }
    public GameState State { get; set; }
    // TODO: NEED WRITE PROMOTION FOR CLIENT SIDE
    public void SetPieces(string? fen, Promation promation)
    {
        Board.SetFen(fen ?? "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR", promation);
    }

    public List<Coordinate> GetAllowedMoves(Piece piece, Coordinate pieceCoordinate)
    {
        if (piece.Color != State.ColorTurn)
            return [];

        return piece.GetAllowedMoves(this.Board, pieceCoordinate);
    }

    public void MakeMove(Piece piece, Coordinate from, Coordinate to)
    {
        piece.MakeMove(Board, from, to);
        OnPiecedMoved?.Invoke();
    }

    private void CheckKing()
    {
        if (Board.IsKingFrightened(State.ColorTurn))
        {
            if (Board.GetAllowedMovesCount(State.ColorTurn) == 0)
            {
                OnMate?.Invoke();
            }
           OnCheck?.Invoke();
        }
    }
    
}
