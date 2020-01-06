using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace skunky.Gravity
{
    public class SmoothBoxGravity : Gravity
    {
        [SerializeField, Range(0,9)]
        public float smoothness;
        public override float Strength(Vector3 position)
        {
            return 1 / transform.worldToLocalMatrix.MultiplyPoint3x4(position).magnitude;
        }
        public override Vector3 getGravityDir(Vector3 position)
        {
            float size;
            position = transform.worldToLocalMatrix.MultiplyPoint3x4(position);
            size = position.magnitude;
            if (size == 0)
                return Vector3.zero;
            position = -position.ScaleToThePowerOf(10 - smoothness);
            position = position * size / position.magnitude;
            return transform.localToWorldMatrix.MultiplyVector(position);
        }
    }
}
