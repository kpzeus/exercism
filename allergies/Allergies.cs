using System;
using System.Collections.Generic;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private int allergenMask;

    public Allergies(int mask)
    {
        this.allergenMask = mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return (this.allergenMask & (int)allergen) == (int)allergen;
    }

    public Allergen[] List()
    {
        var allergens = new List<Allergen>();

        foreach (int item in Enum.GetValues(typeof(Allergen)))
        {
            if((this.allergenMask & item) == item)
            {
                allergens.Add((Allergen)item);
            }
        }

        return allergens.ToArray();
    }
}