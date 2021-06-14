using System;
using System.Collections.Generic;
using System.Linq;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        List<uint> res = new List<uint>();

        if (numbers == null)
            return null;

        foreach (var num in numbers)
        {
            var set = new List<uint>();

            var i = num;

            do
            {
                var lastByte = i & 127;

                if (set.Count != 0)
                {
                    lastByte |= 128;
                }

                set.Add(lastByte);

                i = i >> 7;
            } while (i > 0);

            set.Reverse();
            res.AddRange(set);
        }

        return res.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        List<uint> res = new List<uint>();

        if (bytes == null)
            return null;

        if ((bytes.Last() & 128) != 0)
            throw new InvalidOperationException();

        uint curr = 0;

        foreach (var num in bytes)
        {
            curr = curr << 7;
            curr += num & 127;

            if ((num & 128) == 0)
            {
                res.Add(curr);
                curr = 0;
            }
        }

        return res.ToArray();
    }
}