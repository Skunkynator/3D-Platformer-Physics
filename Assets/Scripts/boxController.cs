using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxRayController3D))]
public class boxController : MonoBehaviour
{
    BoxRayController3D coli;
    // Update is called once per frame
    private void Start()
    {
        coli = GetComponent<BoxRayController3D>();
        coli.GravityDir = Vector3.down;
    }
    void Update()
    {
    }
}
