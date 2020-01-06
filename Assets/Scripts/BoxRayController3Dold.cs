using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider))]
public class BoxRayController3Dold : RayController3D
{
    //boxRayOrigins origins = new boxRayOrigins();
    boxRayOrigins boxEdges = new boxRayOrigins();
    new BoxCollider collider;
    [SerializeField]
    int rayAmountX = 3;
    [SerializeField]
    int rayAmountY = 4;
    [SerializeField]
    int rayAmountZ = 3;
    private Vector3 size;
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
        Debug.DrawLine(ltwMX.MultiplyPoint3x4(boxEdges.backTopRight), ltwMX.MultiplyPoint3x4(boxEdges.frontBotLeft));
        rayAmountY = Mathf.Clamp(rayAmountY, 2, int.MaxValue);
        rayAmountX = Mathf.Clamp(rayAmountX, 2, int.MaxValue);
        rayAmountZ = Mathf.Clamp(rayAmountZ, 2, int.MaxValue);
        //drawDebugLines();
    }

    void initiateBoxEdges()
    {
        Vector3 center = collider.center;
        
        Vector3[] sizes = collider.size.getAllSignVersions();
        boxEdges.backTopRight = (center + sizes[0] / 2);// * (1 - skinWidth / 100);
        boxEdges.backTopLeft = (center + sizes[1] / 2);// * (1 - skinWidth / 100);
        boxEdges.backBotRight = (center + sizes[2] / 2);// * (1 - skinWidth / 100);
        boxEdges.frontTopRight = (center + sizes[3] / 2);// * (1 - skinWidth / 100);
        boxEdges.frontBotLeft = (center + sizes[4] / 2);// * (1 - skinWidth / 100);
        boxEdges.frontBotRight = (center + sizes[5] / 2);// * (1 - skinWidth / 100);
        boxEdges.frontTopLeft = (center + sizes[6] / 2);// * (1 - skinWidth / 100);
        boxEdges.backBotLeft = (center + sizes[7] / 2);// * (1 - skinWidth / 100);
        size = boxEdges.backTopRight - boxEdges.frontBotLeft;
    }

    void drawDebugLines()
    {

        for (int idxZ = 0; idxZ < rayAmountZ; idxZ++)
        {
            Vector3 offsetZ = Vector3.forward * (idxZ / (float)(rayAmountZ - 1)) * size.z;
            for (int idxY = 0; idxY < rayAmountY; idxY++)
            {
                Vector3 offsetY = Vector3.up * (idxY / (float)(rayAmountY - 1)) * size.y;
                Debug.DrawRay(ltwMX.MultiplyPoint3x4(boxEdges.frontBotLeft + offsetY + offsetZ), -transform.right, Color.red);
                Debug.DrawRay(ltwMX.MultiplyPoint3x4(boxEdges.frontBotRight + offsetY + offsetZ), transform.right, Color.red);
            }
            for (int idxX = 0; idxX < rayAmountX; idxX++)
            {
                Vector3 offsetX = Vector3.right * (idxX / (float)(rayAmountX - 1)) * size.x;
                Debug.DrawRay(ltwMX.MultiplyPoint3x4(boxEdges.frontBotLeft + offsetX + offsetZ), -transform.up, Color.red);
                Debug.DrawRay(ltwMX.MultiplyPoint3x4(boxEdges.frontTopLeft + offsetX + offsetZ), transform.up, Color.red);
            }
        }

        for (int idxY = 0; idxY < rayAmountY; idxY++)
        {
            Vector3 offsetY = Vector3.up * (idxY / (float)(rayAmountY - 1)) * size.y;
            for (int idxX = 0; idxX < rayAmountX; idxX++)
            {
                Vector3 offsetX = Vector3.right * (idxX / (float)(rayAmountX - 1)) * size.x;
                Debug.DrawRay(ltwMX.MultiplyPoint3x4(boxEdges.frontBotLeft + offsetY + offsetX), -transform.forward, Color.red);
                Debug.DrawRay(ltwMX.MultiplyPoint3x4(boxEdges.backBotLeft + offsetY + offsetX), transform.forward, Color.red);
            }
        }
    }

    public void move(Vector3 direction)
    {
        Matrix4x4 wtlMX = transform.worldToLocalMatrix;
        direction = wtlMX.MultiplyVector(direction);
        Vector3 currEdge = new Vector3(
            direction.x > 0 ? boxEdges.frontBotRight.x : boxEdges.backBotLeft.x,
            direction.y > 0 ? boxEdges.frontTopLeft.y : boxEdges.frontBotRight.y,
            direction.z > 0 ? boxEdges.backBotLeft.z : boxEdges.frontBotRight.z
        );
        Vector3 XDir = ltwMX.MultiplyVector(new Vector3(direction.x, 0, 0));
        Vector3 YDir = ltwMX.MultiplyVector(new Vector3(0, direction.y, 0));
        Vector3 ZDir = ltwMX.MultiplyVector(new Vector3(0, 0, direction.z));
        float XLength = XDir.magnitude;
        float YLength = YDir.magnitude;
        float ZLength = ZDir.magnitude;
        RaycastHit rayHit;
        for (int idxZ = 0; idxZ < rayAmountZ; idxZ++)
        {
            Vector3 offsetZ = Vector3.forward * (idxZ / (float)(rayAmountZ - 1)) * size.z;
            for (int idxY = 0; idxY < rayAmountY; idxY++)
            {
                Vector3 offsetY = Vector3.up * (idxY / (float)(rayAmountY - 1)) * size.y;
                Debug.DrawRay(ltwMX.MultiplyPoint3x4(currEdge + offsetY + offsetZ), XDir, Color.red);
                if (Physics.Raycast(ltwMX.MultiplyPoint3x4(currEdge + offsetY + offsetZ), XDir, out rayHit, XLength, colissionMask))
                {
                    XLength = rayHit.distance;
                }
            }
            for (int idxX = 0; idxX < rayAmountX; idxX++)
            {
                Vector3 offsetX = Vector3.right * (idxX / (float)(rayAmountX - 1)) * size.x;
                Debug.DrawRay(ltwMX.MultiplyPoint3x4(currEdge + offsetX + offsetZ), YDir, Color.red);
                if (Physics.Raycast(ltwMX.MultiplyPoint3x4(currEdge + offsetX + offsetZ), YDir, out rayHit, YLength, colissionMask))
                {
                    YLength = rayHit.distance;
                }
            }
        }
        for (int idxY = 0; idxY < rayAmountY; idxY++)
        {
            Vector3 offsetY = Vector3.up * (idxY / (float)(rayAmountY - 1)) * size.y;
            for (int idxX = 0; idxX < rayAmountX; idxX++)
            {
                Vector3 offsetX = Vector3.right * (idxX / (float)(rayAmountX - 1)) * size.x;
                Debug.DrawRay(ltwMX.MultiplyPoint3x4(currEdge + offsetX + offsetY), ZDir, Color.red);
                if (Physics.Raycast(ltwMX.MultiplyPoint3x4(currEdge + offsetX + offsetY), ZDir, out rayHit, ZLength, colissionMask))
                {
                    ZLength = rayHit.distance;
                }
            }
        }
        direction = new Vector3(
            XLength * Mathf.Sign(direction.x),
            YLength * Mathf.Sign(direction.y),
            ZLength * Mathf.Sign(direction.z)
            );
        transform.position += direction;
    }

    struct boxRayOrigins
    {
        public Vector3 frontBotLeft, frontBotRight;
        public Vector3 frontTopLeft, frontTopRight;
        public Vector3 backBotLeft, backBotRight;
        public Vector3 backTopLeft, backTopRight;
    }
}
