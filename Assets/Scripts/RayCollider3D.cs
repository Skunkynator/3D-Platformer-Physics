using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class RayCollider3D : MonoBehaviour
{
    [SerializeField]
    float skinWidth = 0.3f;
    List<Vector3> RayCastOrigin = new List<Vector3>();
    public Vector3 GravityDir { 
        get { return gravityDir; } 
        set { gravityDir = value == null ? gravityDir : value.normalized; } 
    }
    private Vector3 gravityDir = Vector3.down;
    public int GravityStrength = 10;
    
    
}
