using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heights
{
    public float Min {get; private set;}
    public float Max {get; private set;}

    public Heights()
    {
        Min = float.MaxValue;
        Max = float.MinValue;
    }

    public void ChangeMaxMin(float point)
    {
        if(point > Max)
        {
            Max = point;
        }
        if(point < Min)
        {
            Min = point;
        }
    }
}
