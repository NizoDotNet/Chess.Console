namespace Chess.Helpers;

public class MoveCoordinate
{
    public int Rank { get; set; }
    public int File { get; set; }
    public MoveCoordinate(int rank, int file)
    {
        Rank = rank;
        File = file;
    }
}
