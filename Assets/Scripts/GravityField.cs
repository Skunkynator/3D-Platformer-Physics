using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using skunky.Fields;
using skunky.Gravity;
using System;

public class GravityField : MonoBehaviour
{
    public delegate Vector3 GravityGetter(Vector3 position,GameObject gameObject);
    static public Dictionary<string, GravityGetter> gravTypes = new Dictionary<string,GravityGetter>();
    static public List<GravityField> allFields = new List<GravityField>();
    private Field field;
    private Gravity grav;
    protected void Start()
    {
        field = GetComponent<Field>();
        grav = GetComponent<Gravity>();
        allFields.Add(this);
        
    }
    public Vector3 getGravityDir(Vector3 position)
    {
        return grav.getGravityDir(position);
    }
    public bool InField(Vector3 position)
    {
        return field.collides(position);
    }
    public float Strength(Vector3 position)
    {
        return grav.Strength(position);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float size = 0.3f;
        Gizmos.DrawLine(transform.position - Vector3.up * size, transform.position + Vector3.up * size);
        Gizmos.DrawLine(transform.position - Vector3.right * size, transform.position + Vector3.right * size);
        Gizmos.DrawLine(transform.position - Vector3.forward * size, transform.position + Vector3.forward * size);
    }
}