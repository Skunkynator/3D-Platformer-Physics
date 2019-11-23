using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class CylindricGravityField : GravityField
{
    [SerializeField]
    float height;
    [SerializeField]
    float width;
    public override Vector3 getGravityDir(Vector3 position)
    {
        position = worldToLoc.MultiplyPoint3x4(position);
        position = position - middle;
        position.y = 0;
        return -position;
    }

    public override bool InField(Vector3 position)
    {
        position = worldToLoc.MultiplyPoint3x4(position);
        position = position - middle;
        bool output = position.y < height;
        if(output)
        {
            position.y = 0;
            output = position.magnitude < width;
        }
        return output;
    }

    public override float Strength(Vector3 position)
    {
        throw new NotImplementedException();
    }
}
