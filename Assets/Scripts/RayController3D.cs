using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class RayCollider3D : MonoBehaviour
{
    public Vector3 ViewDirection
    {
        set
        {
            if (value.normalized != viewDirection.normalized)
            {
                Vector3 val = Vector3.ProjectOnPlane(value, gravityDir);
                if (val != Vector3.zero)
                    viewDirection = val;
                setRotation(viewDirection, gravityDir);
            }
        }
        get { return viewDirection; }
    }
    public Vector3 GravityDir
    {
        set
        {
            if (value.normalized != gravityDir.normalized)
            {
                gravityDir = value;
                ViewDirection = ViewDirection;
                setRotation(viewDirection, gravityDir);
            }
        }
        get { return gravityDir; }
    }
    Vector3 gravityDir = Vector3.down;
    Vector3 viewDirection = Vector3.forward;
    [SerializeField]
    float skinWidth = 0.3f;
    List<Vector3> RayCastOrigin = new List<Vector3>();
    public int GravityStrength = 10;
    private void setRotation(Vector3 directionTest, Vector3 gravityDirTest)
    {
        Quaternion q = transform.localRotation;
        directionTest = Vector3.ProjectOnPlane(directionTest, gravityDirTest);

        q.SetLookRotation(directionTest, gravityDirTest);
        transform.localRotation = q;
    }


}
