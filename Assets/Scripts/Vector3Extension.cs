using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class skunkyExtensions
{
    public static Vector3[] getAllSignVersions(this Vector3 v3)
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
    public static List<Vector3> VectorsPointingAt(this List<Vector3> v3L, Vector3 dir)
    {
        return v3L.VectorsPointingAt(dir, 90);
    }

    public static List<Vector3> VectorsPointingAt(this List<Vector3> v3L, Vector3 dir, float angle)
    {
        List<Vector3> output = new List<Vector3>();
        foreach(Vector3 v3 in v3L)
        {
            if(Vector3.Angle(v3,dir) <= angle)
                output.Add(v3);
        }
        return output;
    }
    public static List<Vector3> subDivide(this List<Vector3> v3l)
    {
        return v3l.subDivide(1);
    }

    public static List<Vector3> subDivide(this List<Vector3> v3l, uint power)

    {
        if (v3l.Count != 4)
            throw new System.Exception("List doesnt contain 4 elements");
        List<Vector3> output = new List<Vector3>();
        List<List<Vector3>> subParts = new List<List<Vector3>>();               
        return output;
    }
}