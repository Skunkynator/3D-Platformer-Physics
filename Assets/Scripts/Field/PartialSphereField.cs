using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace skunky.Fields
{
    public class PartialSphereField : Field
    {
        [SerializeField]
        float radius;
        [SerializeField]
        Vector3 direction;
        [SerializeField]
        float angle;

        public override bool collides(Vector3 position)
        {
            position = transform.worldToLocalMatrix.MultiplyPoint3x4(position);
            return Vector3.Angle(-position, direction) < angle && (-position).magnitude < radius;
        }
    }
}
