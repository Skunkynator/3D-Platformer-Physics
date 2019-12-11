using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider))]
public class BoxRayController3D : RayController3D
{
    //boxRayOrigins origins = new boxRayOrigins();
    boxRayOrigins boxEdges = new boxRayOrigins();
    new BoxCollider collider;
    public GameObject testObject;
    [SerializeField]
    int rayAmountX = 3;
    [SerializeField]
    int rayAmountY = 4;
    [SerializeField]
    int rayAmountZ = 3;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        initiateBoxEdges();
        /*initiateOrigins();
        Vector3 pos = collider.center;
        Matrix4x4 matrix = transform.localToWorldMatrix;
        Vector3 actualPos = matrix.MultiplyPoint3x4(pos);
        Vector3 direction = matrix.MultiplyVector(Vector3.down);
        matrix = transform.worldToLocalMatrix;
        actualPos = matrix.MultiplyPoint3x4(pos);*/
    }

    private void Update()
    {
        ltwMX = transform.localToWorldMatrix;
        testObject.transform.position = ltwMX.MultiplyPoint3x4(boxEdges.backTopLeft);
        Debug.DrawLine(ltwMX.MultiplyPoint3x4(boxEdges.backTopRight), ltwMX.MultiplyPoint3x4(boxEdges.frontBotLeft));
        drawDebugLines();
        /*foreach(List<Vector3> v3l in origins)
        {
            foreach (Vector3 orig in v3l)
            {
                Vector3 eedge = ltwMX.MultiplyPoint3x4(orig);
                Debug.DrawLine(eedge, eedge + Vector3.up / 100,Color.cyan);
            }
        }*/
    }

    void initiateBoxEdges()
    {
        Vector3 center = collider.center;
        
        Vector3[] sizes = collider.size.getAllSignVersions();
        boxEdges.backTopRight = (center + sizes[0] / 2) * (1 - skinWidth / 100);
        boxEdges.backTopLeft = (center + sizes[1] / 2) * (1 - skinWidth / 100);
        boxEdges.backBotRight = (center + sizes[2] / 2) * (1 - skinWidth / 100);
        boxEdges.frontTopRight = (center + sizes[3] / 2) * (1 - skinWidth / 100);
        boxEdges.frontBotLeft = (center + sizes[4] / 2) * (1 - skinWidth / 100);
        boxEdges.frontBotRight = (center + sizes[5] / 2) * (1 - skinWidth / 100);
        boxEdges.frontTopLeft = (center + sizes[6] / 2) * (1 - skinWidth / 100);
        boxEdges.backBotLeft = (center + sizes[7] / 2) * (1 - skinWidth / 100);
    }

    void drawDebugLines()
    {
        rayAmountY = Mathf.Clamp(rayAmountY, 2, int.MaxValue);
        rayAmountX = Mathf.Clamp(rayAmountX, 2, int.MaxValue);
        rayAmountZ = Mathf.Clamp(rayAmountZ, 2, int.MaxValue);

        for (int idxY = 0;idxY < rayAmountY ; idxY++)
        {
            Debug.DrawRay(ltwMX.MultiplyPoint3x4(boxEdges.frontBotLeft + Vector3.up * (idxY / (float)(rayAmountY -1))), Vector3.left, Color.red);
        }
    }

    /*void initiateOrigins()
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
    }*/

    struct boxRayOrigins
    {
        public Vector3 frontBotLeft;
        public Vector3 frontTopLeft;
        public Vector3 frontBotRight;
        public Vector3 frontTopRight;
        public Vector3 backBotLeft;
        public Vector3 backTopLeft;
        public Vector3 backBotRight;
        public Vector3 backTopRight;
    }
}
