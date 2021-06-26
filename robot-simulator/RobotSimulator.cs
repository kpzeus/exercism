using System;

public enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

public class RobotSimulator
{
    private int direction;

    private int x;

    private int y;

    public RobotSimulator(Direction direction, int x, int y)
    {
        this.direction = (int) direction;
        this.x = x;
        this.y = y;
    }

    public Direction Direction
    {
        get
        {
            return (Direction) this.direction;
        }
    }

    public int X
    {
        get
        {
            return this.x;
        }
    }

    public int Y
    {
        get
        {
            return this.y;
        }
    }

    public void Move(string instructions)
    {
        foreach (var op in instructions)
        {
            switch (op)
            {
                case 'L':
                    this.direction -= 1;
                    if (this.direction < 0) this.direction += 4;
                    break;
                case 'R':
                    this.direction += 1;
                    if (this.direction > 3) this.direction -= 4;
                    break;
                case 'A':
                    switch (this.direction)
                    {
                        case 0:
                            y++;
                            break;
                        case 1:
                            x++;
                            break;
                        case 2:
                            y--;
                            break;
                        case 3:
                            x--;
                            break;
                    }
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
