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
    public static Vector3 ScaleToThePowerOf(this Vector3 v3,float power)
    {
        v3.x = Mathf.Pow(Mathf.Abs(v3.x), power) * Mathf.Sign(v3.x);
        v3.y = Mathf.Pow(Mathf.Abs(v3.y), power) * Mathf.Sign(v3.y);
        v3.z = Mathf.Pow(Mathf.Abs(v3.z), power) * Mathf.Sign(v3.z);
        return v3;
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
        foreach(Vector3 v3a in v3l)
        {
            List<Vector3> subDiv = new List<Vector3>();
            foreach(Vector3 v3b in v3l)
            {
                subDiv.Add((v3a + v3b) / 2);
            }
            if (power > 1)
                subDiv = subDiv.subDivide(power - 1);
            output = output.Union(subDiv, new Vector3Comparer()).ToList();
        }          
        return output;
    }
    public static Vector3 closestDirectionTo(this List<Vector3> directions, Vector3 direction)
    {
        Vector3 closestDir = Vector3.one;
        float closestAng = float.PositiveInfinity;
        float currAng;
        foreach (Vector3 dir in directions)
        {
            currAng = Vector3.Angle(dir, direction);
            if (currAng < closestAng)
            {
                closestAng = currAng;
                closestDir = dir;
            }
        }
        return closestDir;
    }
    public static Vector3 Divide(this Vector3 vec1, Vector3 divisor)
    {
        vec1.x /= divisor.x;
        vec1.y /= divisor.y;
        vec1.z /= divisor.z;
        return vec1;
    }

    public static Vector3 multiply(this Vector3 vec1, Vector3 mult)
    {
        vec1.x *= mult.x;
        vec1.y *= mult.y;
        vec1.z *= mult.z;
        return vec1;
    }

    public static float sumOfCoord(this Vector3 vect)
    {
        return vect.x + vect.y + vect.z;
    }
}