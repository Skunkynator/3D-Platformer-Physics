using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider))]
public class BoxRayCollider3D : RayCollider3D
{
    boxRayOrigins origins = new boxRayOrigins();
    List<Vector3> boxEdges = new List<Vector3>();
    new BoxCollider collider;
    public GameObject testObject;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        initiateBoxEdges();
        initiateOrigins();
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
        foreach(Vector3 edge in boxEdges)
        {
            Vector3 eedge = ltwMX.MultiplyPoint3x4(edge);
            Debug.DrawLine(eedge, eedge + Vector3.up / 10);
        }
    }

    void initiateBoxEdges()
    {
        boxEdges = new List<Vector3>();
        Vector3 center = collider.center;
        
        Vector3[] sizes = collider.size.getAllSignVersions();
        foreach(Vector3 size in sizes)
        {
            boxEdges.Add(center + size/2);
        }
    }

    void initiateOrigins()
    {
        origins.up = boxEdges.VectorsPointingAt(Vector3.up);
        origins.down = boxEdges.VectorsPointingAt(Vector3.down);
        origins.left = boxEdges.VectorsPointingAt(Vector3.left);
        origins.right = boxEdges.VectorsPointingAt(Vector3.right);
        origins.forward = boxEdges.VectorsPointingAt(Vector3.forward);
        origins.back = boxEdges.VectorsPointingAt(Vector3.back);
    }



    struct boxRayOrigins
    {
        public List<Vector3> up;
        public List<Vector3> down;
        public List<Vector3> left;
        public List<Vector3> right;
        public List<Vector3> forward;
        public List<Vector3> back;
    }
}
