using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGravityField : GravityField
{
    Vector3 middle;
    float height;
    float length;
    float width;
    Vector3 size;
    public override Vector3 getGravityDir(Vector3 position)
    {
        position = worldToLoc.MultiplyPoint3x4(position);
        position = position.Divide(size);
        Vector3 dir = middle - position;

        throw new System.NotImplementedException();
    }
    public override bool inField(Vector3 position)
    {
        position = worldToLoc.MultiplyPoint3x4(position);
        return Mathf.Abs(middle.y - position.y) < size.y / 2 ||
            Mathf.Abs(middle.z - position.z) < size.z / 2 ||
            Mathf.Abs(middle.x - position.x) < size.x / 2;
    }
    public override float Strength(Vector3 position)
    {
        throw new System.NotImplementedException();
    }
}
