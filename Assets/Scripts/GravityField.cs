using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GravityField : MonoBehaviour
{
    static public List<GravityField> allFields = new List<GravityField>();
    protected Matrix4x4 locToWorld;
    protected Matrix4x4 worldToLoc;
    protected bool SingleDir;
    [SerializeField]
    protected Vector3 middle;
    Vector3 dir;
    protected List<Vector3> allDir = new List<Vector3>();
    private void Start()
    {
        allDir.Add(Vector3.up);
        allDir.Add(Vector3.down);
        allDir.Add(Vector3.left);
        allDir.Add(Vector3.right);
        allDir.Add(Vector3.forward);
        allDir.Add(Vector3.back);
        locToWorld = transform.localToWorldMatrix;
        worldToLoc = transform.worldToLocalMatrix;
        allFields.Add(this);
    }
    public abstract Vector3 getGravityDir(Vector3 position);

    protected Vector3 getGravityDir()
    {
        return dir;
    }
    abstract public bool InField(Vector3 position);
    abstract public float Strength(Vector3 position);
}