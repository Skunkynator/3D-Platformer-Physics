using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class RayController3D : MonoBehaviour
{
    public Vector3 ViewDirection
    {
        set
        {
            Vector3 val = Vector3.ProjectOnPlane(value, gravityDir);
            //Debug.Log(val);
            if (val != Vector3.zero)
                viewDirection = val;
            else
                viewDirection = Vector3.Cross(gravityDir, new Vector3(gravityDir.y, gravityDir.z, gravityDir.x));

            setRotation(viewDirection, gravityDir);
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
                setRotation(viewDirection, -gravityDir);
            }
        }
        get { return gravityDir; }
    }
    public LayerMask colissionMask;
    Vector3 gravityDir = Vector3.down;
    Vector3 viewDirection = Vector3.forward;
    [SerializeField]
    protected float skinWidth = 0.3f;
    protected Matrix4x4 ltwMX;
    List<Vector3> RayCastOrigin = new List<Vector3>();
    public int GravityStrength = 10;
    private void setRotation(Vector3 directionTest, Vector3 gravityDirTest)
    {
        Quaternion q = transform.localRotation;
        q.SetLookRotation(directionTest, gravityDirTest);
        transform.localRotation = q;
    }



}
