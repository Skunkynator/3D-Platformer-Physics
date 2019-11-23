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
        foreach(List<Vector3> v3l in origins)
        {
            foreach (Vector3 orig in v3l)
            {
                Vector3 eedge = ltwMX.MultiplyPoint3x4(orig);
                Debug.DrawLine(eedge, eedge + Vector3.up / 100,Color.cyan);
            }
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
        origins.up = boxEdges.VectorsPointingAt(Vector3.up).subDivide(3);
        origins.down = boxEdges.VectorsPointingAt(Vector3.down).subDivide(3);
        origins.left = boxEdges.VectorsPointingAt(Vector3.left).subDivide(3);
        origins.right = boxEdges.VectorsPointingAt(Vector3.right).subDivide(3);
        origins.forward = boxEdges.VectorsPointingAt(Vector3.forward).subDivide(3);
        origins.back = boxEdges.VectorsPointingAt(Vector3.back).subDivide(3);
    }



    struct boxRayOrigins : IEnumerable
    {
        public List<Vector3> up;
        public List<Vector3> down;
        public List<Vector3> left;
        public List<Vector3> right;
        public List<Vector3> forward;
        public List<Vector3> back;

        public IEnumerator GetEnumerator()
        {
            List<List<Vector3>> output = new List<List<Vector3>>();
            output.Add(up);
            output.Add(down);
            output.Add(left);
            output.Add(right);
            output.Add(forward);
            output.Add(back);
            return output.GetEnumerator();
        }
    }
}
