using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

namespace skunky.Fields
{
    public class BoxField : Field
    {
        [SerializeField]
        Vector3 size;

        public override bool collides(Vector3 position)
        {
            position = transform.worldToLocalMatrix.MultiplyPoint3x4(position);
            return Mathf.Abs(position.y) < size.y / 2 &&
                Mathf.Abs(position.z) < size.z / 2 &&
                Mathf.Abs(position.x) < size.x / 2;
        }
    }
}
