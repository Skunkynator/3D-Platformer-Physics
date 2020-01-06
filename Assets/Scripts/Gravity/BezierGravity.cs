using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

namespace skunky.Gravity
{
    public class BezierGravity : Gravity
    {
        [SerializeField]
        BezierSpline curve;
        [SerializeField, Range(1, 10000)]
        int precision = 100;
        public override float Strength(Vector3 position)
        {
            return 1 / getGravityDir(position).magnitude;
        }
        public override Vector3 getGravityDir(Vector3 position)
        {
            return curve.FindNearestPointTo(position, precision) - position;
        }
    }
}
