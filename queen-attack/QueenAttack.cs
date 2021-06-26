using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }

    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        int[,] m = new int[8, 8];

        m[white.Row, white.Column] = 1;
        m[black.Row, black.Column] = 1;

        //Rows
        var count = 0;
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                if (m[i, j] == 1)
                {
                    count++;
                }

                if (count == 2) return true;
            }
            count = 0;
        }

        //Columns
        count = 0;
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                if (m[j, i] == 1)
                {
                    count++;
                }

                if (count == 2) return true;
            }
            count = 0;
        }

        //Diagional1
        count = 0;
        var r = white.Row - 1;
        var c = white.Column - 1;
        while (r > -1 && c > -1)
        {
            if (m[r, c] == 1) return true;

            r--;
            c--;
        }
        r = white.Row + 1;
        c = white.Column + 1;
        while (r < 8 && c < 8)
        {
            if (m[r, c] == 1) return true;

            r++;
            c++;
        }

        //Diagional2
        count = 0;
        r = white.Row + 1;
        c = white.Column - 1;
        while (r < 8 && c > -1)
        {
            if (m[r, c] == 1) return true;

            r++;
            c--;
        }
        r = white.Row - 1;
        c = white.Column + 1;
        while (r > -1 && c < 8)
        {
            if (m[r, c] == 1) return true;

            r--;
            c++;
        }

        return false;
    }

    public static Queen Create(int row, int column)
    {
        if (row < 0 || column < 0 || row > 7 || column > 7)
            throw new ArgumentOutOfRangeException();

        return new Queen(row, column);
    }
}
