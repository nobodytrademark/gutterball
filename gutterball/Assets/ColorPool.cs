using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPool
{
    public static Color[] pool = { Color.black, Color.blue, Color.green, Color.red, Color.magenta };

    public static Color getColor(int i)
    {
        if (i > ColorPool.pool.Length - 1)
        {
            return Color.cyan;
        }
        else {
            return ColorPool.pool[i];
        }
    }

}
