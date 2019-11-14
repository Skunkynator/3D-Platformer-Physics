using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class skunkyExtensions
{
    public static Vector3[] getAllVersions(this Vector3 v3)
    {
        Vector3[] output = new Vector3[8];
        output[0] = v3;
        v3.x *= -1;
        output[1] = v3;
        v3.x *= -1;
        v3.y *= -1;
        output[2] = v3;
        v3.y *= -1;
        v3.z *= -1;
        output[3] = v3;
        for (int idx = 0; idx < 4; idx++)
            output[idx + 4] = -output[idx];
        return output;
    }
}
