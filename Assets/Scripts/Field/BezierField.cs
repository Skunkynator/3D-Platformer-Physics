using BezierSolution;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace skunky.Fields
{
    public class BezierField : Field
    {
        [SerializeField]
        BezierSpline curve;
        [SerializeField]
        float width = 0.5f;
        [SerializeField, Range(1, 10000)]
        int precision = 100;

        public override bool collides(Vector3 position)
        {
            Collider test = new Collider();
            return (curve.FindNearestPointTo(position, precision) - position).magnitude < width;
        }
    }
}