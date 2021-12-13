using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPool
{
    public static Color[] pool = { Color.white, new Color(0.1843137f, 0.509804f, 0.6784314f),
        new Color(0.2313726f, 0.7294118f, 0.572549f), new Color(0.8039216f, 0.7843138f, 0.2901961f), 
        new Color(0.7803922f, 0.4431373f, 0.3137255f) };
    public static Color[] redpool = { new Color(0.8f, 0f, 0f), new Color(0.5f, 0f, 0f), new Color(0.3f, 0f, 0f) };

    public static Color getColor(int i)
    {
        if (i > ColorPool.pool.Length - 1)
        {
            return new Color(0.7803922f, 0.3137255f, 0.3137255f);
        }
        else {
            return ColorPool.pool[i - 1];
        }
    }

    public static Color getRed(int i)
    {
        if (i > ColorPool.redpool.Length - 1)
        {
            return Color.red;
        }
        else
        {
            return ColorPool.redpool[i - 1];
        }
    }

}
