using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGravityField : GravityField
{
    Vector3 position;
    float radius;

    public override Vector3 getGravityDir(Vector3 position)
    {
        return SingleDir ? getGravityDir() : locToWorld.MultiplyPoint3x4(this.position) - position;
    }

    public override bool inField(Vector3 position)
    {
        return getGravityDir(position).magnitude > radius;
    }

    public override float Strength(Vector3 position)
    {
        throw new System.NotImplementedException();
    }
}
