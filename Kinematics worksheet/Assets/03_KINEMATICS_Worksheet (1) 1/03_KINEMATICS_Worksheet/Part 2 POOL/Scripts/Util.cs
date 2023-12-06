using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        //To find the distance, you just need to find the difference in magnitude between 2 points
        return (p2 - p1).Magnitude();
    }
}

