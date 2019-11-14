using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider))]
public class BoxRayCollider3D : RayCollider3D
{
    new BoxCollider collider;
    List<Vector3> boxEdges = new List<Vector3>();
    public GameObject testObject;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        initiateBoxEdges();
        /*Vector3 pos = collider.center;
        Matrix4x4 matrix = transform.localToWorldMatrix;
        Vector3 actualPos = matrix.MultiplyPoint3x4(pos);
        Vector3 direction = matrix.MultiplyVector(Vector3.down);
        matrix = transform.worldToLocalMatrix;
        actualPos = matrix.MultiplyPoint3x4(pos);*/
    }

    private void Update()
    {
        Matrix4x4 ltwMX = transform.localToWorldMatrix;
        testObject.transform.position = ltwMX.MultiplyPoint3x4(boxEdges[0]);
        Debug.DrawLine(ltwMX.MultiplyPoint3x4(boxEdges[1]), ltwMX.MultiplyPoint3x4(boxEdges[1]) - transform.right);
    }

    void initiateBoxEdges()
    {
        boxEdges = new List<Vector3>();
        Vector3 center = collider.center;
        
        Vector3[] sizes = collider.size.getAllVersions();
        foreach(Vector3 size in sizes)
        {
            boxEdges.Add(center + size/2);
        }
        boxRayOrigins a = new boxRayOrigins();
    }

    struct boxRayOrigins
    {
        List<Vector3> up;
        List<Vector3> down;
        List<Vector3> left;
        List<Vector3> right;
        List<Vector3> forward;
        List<Vector3> back;
    }
}
