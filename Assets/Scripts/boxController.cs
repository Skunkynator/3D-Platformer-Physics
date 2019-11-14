using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxController : MonoBehaviour
{
    [SerializeField]
    BoxRayCollider3D coli;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        coli.GravityDir = transform.up;//localToWorldMatrix.MultiplyVector(Vector3.up);
        coli.ViewDirection = transform.forward;//localToWorldMatrix.MultiplyVector(Vector3.forward);
    }
}
