using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GravityField : MonoBehaviour
{
    static public List<GravityField> allFields = new List<GravityField>();
    protected Matrix4x4 locToWorld;
    protected Matrix4x4 worldToLoc;
    protected bool SingleDir;
    Vector3 dir;
    private void Start()
    {
        locToWorld = transform.localToWorldMatrix;
        allFields.Add(this);
    }
    public abstract Vector3 getGravityDir(Vector3 position);

    protected Vector3 getGravityDir()
    {
        return dir;
    }
    abstract public bool inField(Vector3 position);
    abstract public float Strength(Vector3 position);
}