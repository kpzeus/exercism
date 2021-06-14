using System;

public class SpaceAge
{
    double seconds = 0;

    public SpaceAge(int seconds)
    {
        if(seconds < 0)
        {
            throw new ArgumentException();
        }

        this.seconds = seconds;
    }

    private double OnEarthRaw()
    {
        return this.seconds / 31557600;
    }

    public double OnEarth()
    {
        return Math.Round(this.OnEarthRaw(), 2);
    }

    public double OnMercury()
    {
        return Math.Round(this.OnEarthRaw() / 0.2408467, 2);
    }

    public double OnVenus()
    {
        return Math.Round(this.OnEarthRaw() / 0.61519726, 2);
    }

    public double OnMars()
    {
        return Math.Round(this.OnEarthRaw() / 1.8808158, 2);
    }

    public double OnJupiter()
    {
        return Math.Round(this.OnEarthRaw() / 11.862615, 2);
    }

    public double OnSaturn()
    {
        return Math.Round(this.OnEarthRaw() / 29.447498, 2);
    }

    public double OnUranus()
    {
        return Math.Round(this.OnEarthRaw() / 84.016846, 2);
    }

    public double OnNeptune()
    {
        return Math.Round(this.OnEarthRaw() / 164.79132, 2);
    }
}