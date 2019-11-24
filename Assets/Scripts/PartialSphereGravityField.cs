using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartialSphereGravityField : SphereGravityField
{
    [SerializeField]
    Vector3 direction;
    [SerializeField]
    float angle;
    public override bool InField(Vector3 position)
    {
        return Vector3.Angle(-base.getGravityDir(position), direction) < angle && base.InField(position);
    }
}
