﻿namespace Chess.Helpers;

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
            if(value < 1 || value > 9) throw new ArgumentOutOfRangeException();
            rank = value;
        } }
    public Helpers.File File { get => file; 
        set
        {
            file = value;
        }
    }

}
