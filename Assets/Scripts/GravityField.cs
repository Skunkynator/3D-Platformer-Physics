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
        new BezierCurve(new Vector3(30, 10), new Vector3(30, 160), new Vector3(-60, 34), new Vector3(75, 40));

    }
    public abstract Vector3 getGravityDir(Vector3 position);

    protected Vector3 getGravityDir()
    {
        return dir;
    }
    abstract public bool InField(Vector3 position);
    abstract public float Strength(Vector3 position);
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float size = 0.3f;
        Gizmos.DrawLine(transform.position - Vector3.up * size, transform.position + Vector3.up * size);
        Gizmos.DrawLine(transform.position - Vector3.right * size, transform.position + Vector3.right * size);
        Gizmos.DrawLine(transform.position - Vector3.forward * size, transform.position + Vector3.forward * size);
    }
}