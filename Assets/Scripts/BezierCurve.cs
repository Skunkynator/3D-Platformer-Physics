using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using Vector3 = UnityEngine.Vector3; 

public class BezierCurve
{
    private Vector3 start, contrA, contrB, end;
    private Vector3[] coeffs;
    public BezierCurve(Vector3 Start, Vector3 ContrA, Vector3 ContrB, Vector3 End)
    {
        start = Start;
        contrA = ContrA;
        contrB = ContrB;
        end = End;
        initCoeffs();
        
    }

    private void initCoeffs()
    {
        coeffs = new Vector3[4];
        coeffs[0] = end + 3 * contrA - 3 * contrB - start;
        coeffs[1] = 3 * start + 3 * contrB - 6 * contrA;
        coeffs[2] = 3 * contrA - 3 * start;
        coeffs[3] = start;
    }

    public Vector3 pointAt(float t)
    {
        return (1 - t) * (1 - t) * (1 - t) * start + 
            3 * ((1 - t * (1 - t))) * t * contrA + 
            3 * (1 - t) * t * t * contrB + 
            3 * t * t * t * end;
    }

    public Vector3[] pointsAt(float[] t)
    {
        Vector3[] output = new Vector3[t.Length - 1];
        for(int idx=0; idx < t.Length; idx++)
        {
            output[idx] = pointAt(t[idx]);
        }
        return output;
    }

    public Vector3 closestPointTo(Vector3 p)
    {
        List<double> dcoeffs = new List<double>();
        dcoeffs.Add(coeffs[0].multiply(coeffs[0]).sumOfCoord() * 6);
        dcoeffs.Add(coeffs[0].multiply(coeffs[1]).sumOfCoord() * 10);
        dcoeffs.Add(coeffs[1].multiply(coeffs[1]).sumOfCoord() * 4 + coeffs[0].multiply(coeffs[2]).sumOfCoord()*2);
        dcoeffs.Add(coeffs[0].multiply(coeffs[3]-p).sumOfCoord() * 6 + coeffs[1].multiply(coeffs[2]).sumOfCoord());
        dcoeffs.Add(coeffs[2].multiply(coeffs[2]).sumOfCoord() * 2 + coeffs[1].multiply(coeffs[3] - p).sumOfCoord() * 4);
        dcoeffs.Add(coeffs[2].multiply(coeffs[3]-p).sumOfCoord() * 2);
        List<float> potentials = realRootsOToOne(dcoeffs);
        potentials.Add(0);
        potentials.Add(1);
        float min = float.MaxValue;
        float dist;
        Vector3 output = Vector3.zero;
        foreach(float point in potentials)
        {
            dist = (p - pointAt(point)).magnitude;
            if(dist < min)
            {
                min = dist;
                output = pointAt(point) - p;
            }
        }
        return output;
    }

    public List<float> realRootsOToOne(List<double> coeffs)
    {
        List<Complex> roots = RealPolynomialRootFinder.FindRoots(coeffs.ToArray());
        List<float> output = new List<float>();
        foreach(Complex c in roots)
        {
            if(Mathf.Abs((float)c.Imaginary) > 1e-15f)
                if((float)c.Real>1)
                    output.Add((float)c.Real);
        }
        return output;
    }
}
