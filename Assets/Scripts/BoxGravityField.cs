using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGravityField : GravityField
{
    [SerializeField]
    Vector3 size;

    public override Vector3 getGravityDir(Vector3 position)
    {
        position = worldToLoc.MultiplyPoint3x4(position);
        Vector3 dir = middle - position;
        dir = dir.Divide(size);
        return allDir.closestDirectionTo(dir);
    }
    public override bool InField(Vector3 position)
    {
        position = worldToLoc.MultiplyPoint3x4(position);
        position = position - middle;
        return Mathf.Abs(position.y) < size.y / 2 &&
            Mathf.Abs(position.z) < size.z / 2 &&
            Mathf.Abs(position.x) < size.x / 2;
    }
    public override float Strength(Vector3 position)
    {
        return 10;
    }
}
