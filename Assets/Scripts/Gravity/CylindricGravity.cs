using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace skunky.Gravity
{
    public class CylindricGravity : Gravity
    {
        public override float Strength(Vector3 position)
        {
            return 1 / getGravityDir(position).magnitude;
        }
        public override Vector3 getGravityDir(Vector3 position)
        {
            position = transform.worldToLocalMatrix.MultiplyPoint3x4(position);
            position.y = 0;
            position = transform.localToWorldMatrix.MultiplyVector(position);
            return -position;
        }
    }
}
