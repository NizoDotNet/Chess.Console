using Chess.Helpers;
using Chess.Main;
using Chess.Pieces;

namespace Chess.Tests.Pieces;

public class PawnMoveTest
{
    [Fact]
    public void Pawn_Should_Not_Jump_Over_Piece()
    {
        var board = new Board();
        board.SetFen("4k3/8/8/8/8/5N2/PPPP1PPP/4K3/", null);
        Helpers.Coordinate coordinate = new(2, Helpers.File.F);
        var pawn = board.PieceAndCoordinates[coordinate];

        // 
        var moves = pawn.GetAllowedMoves(board, coordinate);

        Assert.Empty(moves);
    }

    [Fact]
    public void Pawn_Should_Return_2_Avaible_Moves()
    {
        var board = new Board();
        board.SetFen("4k3/8/8/8/8/8/PPPP1PPP/4K3/", null);
        Helpers.Coordinate coordinate = new(2, Helpers.File.F);
        var pawn = board.PieceAndCoordinates[coordinate];

        var moves = pawn.GetAllowedMoves(board, coordinate);

        Assert.Equal(2, moves.Count);
        Assert.Contains(moves, item => item.Rank == 3 && item.File == Helpers.File.F);
        Assert.Contains(moves, item => item.Rank == 4 && item.File == Helpers.File.F);

    }

    [Fact]
    public void Pawn_Should_Return_3_Avaible_Moves()
    {
        var board = new Board();
        board.SetFen("4k3/8/8/8/8/4p3/PPPP1PPP/4K3/", null);
        Helpers.Coordinate coordinate = new(2, Helpers.File.F);
        var pawn = board.PieceAndCoordinates[coordinate];

        var moves = pawn.GetAllowedMoves(board, coordinate);

        Assert.Equal(3, moves.Count);
        Assert.Contains(moves, item => item.Rank == 3 && item.File == Helpers.File.F);
        Assert.Contains(moves, item => item.Rank == 4 && item.File == Helpers.File.F);
        Assert.Contains(moves, item => item.Rank == 3 && item.File == Helpers.File.E);

    }

    [Theory]
    [InlineData(7, 0, true)]
    [InlineData(2, 1, true)]
    [InlineData(7, 1, false)]
    [InlineData(2, 0, false)]
    public void CheckPromotion_Test(int rank, int color, bool expectedValue)
    {
        var board = new Board();
        board.SetFen("4k3/8/8/8/8/8/8/4K3/", null);
        Helpers.Coordinate coordinate = new(rank, Helpers.File.A);
        Pawn piece = new Pawn((Color)color);
        board.SetPiece(piece, coordinate);

        var moveTo = coordinate with
        {
            Rank = rank + (color == 0 ? 1 : -1)
        };

        var res = piece.CheckPromotion(moveTo);

        Assert.Equal(expectedValue, res);
    }

}
