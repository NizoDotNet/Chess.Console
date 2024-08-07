﻿using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;
public class Pawn : Piece, IPawn
{

    public Pawn(Color color) : base(color)
    {
        isMoved = false;

    }
    public Pawn(Color color, Promation promation) : base(color)
    {
        isMoved = false;
        PromationEvent = promation;
    }


    public bool isMoved { get; set; }

    public override PieceType Type => PieceType.Pawn;

    public event Promation PromationEvent;

    public IEnumerable<Coordinate> CanTakePiece(Board board, Coordinate coordinate)
    {
        if(this.Color == Color.White)
        {
            if(coordinate.File != Helpers.File.A)
            {
                var checkCoordinate = new Coordinate(coordinate.Rank + 1, coordinate.File - 1);
                if (board.PieceAndCoordinates.TryGetValue(checkCoordinate, out var piece)
                    && piece.Color == Color.Black)
                {
                    yield return checkCoordinate;
                }
            }
            if(coordinate.File != Helpers.File.H)
            {
                var checkCoordinate = new Coordinate(coordinate.Rank + 1, coordinate.File + 1);
                if (board.PieceAndCoordinates.TryGetValue(checkCoordinate, out var piece)
                    && piece.Color == Color.Black)
                {
                    yield return checkCoordinate;
                }
            }
            
        }
        else
        {
            if (coordinate.File != Helpers.File.A)
            {
                var checkCoordinate = new Coordinate(coordinate.Rank - 1, coordinate.File - 1);
                if (board.PieceAndCoordinates.TryGetValue(checkCoordinate, out var piece)
                    && piece.Color == Color.White)
                {
                    yield return checkCoordinate;
                }
            }
            if (coordinate.File != Helpers.File.H)
            {
                var checkCoordinate = new Coordinate(coordinate.Rank - 1, coordinate.File + 1);
                if (board.PieceAndCoordinates.TryGetValue(checkCoordinate, out var piece)
                    && piece.Color == Color.White)
                {
                    yield return checkCoordinate;
                }
            }

        }
    }

    public bool CheckPromation(Coordinate coordinate)
    {
        if (this.Color == Color.Black && coordinate.Rank == 1) return true;
        if(this.Color == Color.White && coordinate.Rank == 8) return true;
        return false;
    }

    public override IEnumerable<Coordinate> GetAllMoves(Board board, Coordinate coordinate)
    {
        var moveCoordinates = MoveCoordinates();
        var coordinates = new List<Coordinate>();
        foreach (var move in moveCoordinates)
        {
            Coordinate checkCoordinate = new(coordinate.Rank + move.Rank, coordinate.File);
            if (!board.PieceAndCoordinates.ContainsKey(checkCoordinate))
            {
                yield return checkCoordinate;
            }
        }
        foreach (var move in CanTakePiece(board, coordinate))
            yield return move;      
    }


    public IEnumerable<MoveCoordinate>  MoveCoordinates()
    {
        if(!isMoved)
        {
            if(this.Color == Color.White)
                yield return new MoveCoordinate(2, 0);
            
            else 
                yield return new MoveCoordinate(-2, 0);
        }
        if(this.Color == Color.White)
        {
            yield return new MoveCoordinate(1, 0);
        }
        else
        {
            yield return new MoveCoordinate(-1, 0);
        }
    }

    public override void MakeMove(Board board, Coordinate from, Coordinate to)
    {
        var piece = CheckPromation(to) ? OnPromotion() : this;
        
        board.RemovePiece(from);
        board.RemovePiece(to);
        board.SetPiece(piece, to);
        isMoved = true;

    }

    public Piece OnPromotion()
    {
        return PromationEvent?.Invoke(Color);
    }
}
