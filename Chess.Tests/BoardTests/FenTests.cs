using Chess.Main;

namespace Chess.Tests.BoardTests;

public class FenTests
{

    [Theory]
    [InlineData("r1bqk2r/pppp1ppp/2n5/4p3/2B1P3/5N2/PPPP1PPP/RNBQ1RK1/")]
    [InlineData("rnbq1rk1/pp2bppp/2p1pn2/3p4/3P4/2NBPN2/PP3PPP/R1BQ1RK1/")]
    [InlineData("2rq1rk1/pp3ppp/2n1bn2/2bp4/8/2NP1NP1/PP2PPBP/R1BQ1RK1/")]
    [InlineData("r3k2r/ppp2ppp/2n1bn2/3qp3/3P4/2N1PN2/PPQ2PPP/R3KB1R/")]
    [InlineData("rnbqkb1r/pppp1ppp/5n2/4p3/2B1P3/3P4/PPP2PPP/RNBQK1NR/")]
    public void GetFen_Test(string fen)
    {
        // Arrange
        Board board = new();
        board.SetFen(fen, null);

        // Act
        string getFen = board.GetFen();

        // Assert
        Assert.Equal(fen, getFen);
    }
}
