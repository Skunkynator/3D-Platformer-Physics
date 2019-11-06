using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxRayCollider3D : RayCollider3D
{
    new BoxCollider collider;
    [SerializeField]
    Vector3 directionTest = Vector3.forward;
    [SerializeField]
    Vector3 gravityDirTest = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        Vector3 pos = collider.center;
        Matrix4x4 matrix = transform.localToWorldMatrix;
        Vector3 actualPos = matrix.MultiplyPoint3x4(pos);
        Vector3 direction = matrix.MultiplyVector(Vector3.down);
        matrix = transform.worldToLocalMatrix;
        actualPos = matrix.MultiplyPoint3x4(pos);
    }
    private void LateUpdate()
    {
        Quaternion q = transform.localRotation;
        q.SetLookRotation(directionTest,gravityDirTest);
        transform.localRotation = q;
    }

}
