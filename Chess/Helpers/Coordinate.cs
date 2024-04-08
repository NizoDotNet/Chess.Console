namespace Chess.Helpers;

public record Coordinate
{
    private int rank;
    private File file;

    public Coordinate()
    {
        
    }
    public Coordinate(int rank, File file)
    {
        Rank = rank;
        File = file;
    }

    public int Rank { get => rank; 
        set 
        {
            if(value < 1 || value > 8) throw new ArgumentOutOfRangeException();
            rank = value;
        } }
    public Helpers.File File { get => file; 
        set
        {
            if((int)value < 1 || (int)value > 8) throw new ArgumentOutOfRangeException();
            file = value;
        }
    }


    public override string ToString()
    {
        return $"{File}{Rank}";
    }
}
