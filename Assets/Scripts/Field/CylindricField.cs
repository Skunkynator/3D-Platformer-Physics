using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace skunky.Fields
{
    public class CylindricField : Field
    {
        [SerializeField]
        float width;
        [SerializeField]
        float height;
        public override bool collides(Vector3 position)
        {
            position = transform.worldToLocalMatrix.MultiplyPoint3x4(position);
            bool output = Mathf.Abs(position.y) < height/2;
            if (output)
            {
                position.y = 0;
                output = position.magnitude < width;
            }
            return output;
        }
    }
}
