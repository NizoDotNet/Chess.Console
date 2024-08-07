﻿using Chess.Helpers;
using Chess.Main;

namespace Chess.Pieces;

public interface IPawn
{
    public bool isMoved { get; set; }
    public event Promation PromationEvent;

    IEnumerable<Coordinate> CanTakePiece(Board board, Coordinate coordinate);
    bool CheckPromation(Coordinate coordinate);
    public Piece OnPromotion();

}
