using System;

public enum Schedule
{
    Teenth = 5,
    First = 1,
    Second = 2,
    Third = 3,
    Fourth = 4,
    Last = 6
}

public class Meetup
{
    int month;
    int year;

    public Meetup(int month, int year)
    {
        this.month = month;
        this.year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        DateTime r = new DateTime(year, month, 1);
        DateTime prev = r;
        int offset = (int)schedule;

        while (offset > 0)
        {
            while (r.DayOfWeek != dayOfWeek)
            {
                r = r.AddDays(1);
            }

            switch (offset)
            {
                case 6:
                    if (r.Month > this.month || (r.Month == 1 && this.month == 12))
                    {
                        return prev;
                    }
                    else
                    {
                        prev = r;
                        r = r.AddDays(1);
                    }
                    break;

                case 5:
                    if (r.Day > 9 && r.Day < 20)
                    {
                        if (prev.Day > 9 && prev.Day < 20)
                        {
                            return r;
                        }
                        else
                        {
                            if (r.Day + 7 < 20)
                            {
                                return r.AddDays(7);
                            }
                            else
                            {
                                return r;
                            }
                        }
                    }
                    else
                    {
                        prev = r;
                        r = r.AddDays(1);
                    }
                    break;

                default:
                    if (offset > 1)
                    {
                        r = r.AddDays(1);
                    }
                    offset--;
                    break;
            }
        }

        return r;
    }
}