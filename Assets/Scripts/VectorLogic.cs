using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VectorLogic
{

    static public float Angle(Vector2 v)
    {
        float angle;
        v.Normalize();
        if (v.y >= 0)
        {
            if (v.x >= 0)
                angle = -Mathf.Acos(v.y) * Mathf.Rad2Deg;
            else
                angle = Mathf.Acos(v.y) * Mathf.Rad2Deg;
        }
        else
        {
            if (v.x <= 0)
                angle = -(Mathf.Asin(v.y) - Mathf.PI / 2) * Mathf.Rad2Deg;
            else
                angle = (Mathf.Asin(v.y) - Mathf.PI / 2) * Mathf.Rad2Deg;
        }
        return angle;
    }
}
