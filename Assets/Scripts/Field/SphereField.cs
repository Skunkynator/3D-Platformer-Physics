using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace skunky.Fields
{
    public abstract class SphereField : Field
    {
        [SerializeField]
        float radius;

        public override bool collides(Vector3 position)
        {
            return ( -transform.worldToLocalMatrix.MultiplyPoint3x4( position)).magnitude < radius;
        }
    }
}
