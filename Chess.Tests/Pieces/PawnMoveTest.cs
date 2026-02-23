using Chess.Main;

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
}
