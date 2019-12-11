using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class BezierGravityField : GravityField
{
    BezierCurve curve;
    Vector3 Start;
    Vector3 contrA;
    Vector3 contrB;
    Vector3 End;

    public override Vector3 getGravityDir(Vector3 position)
    {
        return curve.closestPointTo(position);
    }

    public override bool InField(Vector3 position)
    {
        throw new NotImplementedException();
    }

    public override float Strength(Vector3 position)
    {
        return 1;
    }
}
