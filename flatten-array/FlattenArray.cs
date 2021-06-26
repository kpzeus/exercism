using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        if (input != null)
        {
            foreach (var item in input)
            {
                if (item is IEnumerable)
                {
                    var items = Flatten(item as IEnumerable);
                    foreach (var item2 in items)
                    {
                        if (item2 != null)
                            yield return item2;
                    }
                }
                else
                {
                    if (item != null)
                        yield return item;
                }
            }
        }
    }
}