using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private void Update()
    {
        Vector3 pos = transform.position;
        Debug.DrawLine(pos, pos + checkForGravity(pos));
    }
    public Vector3 checkForGravity(Vector3 position)
    {
        Vector3 output = Vector3.zero;
        int idx = 0;
        List<GravityField> foundGravitys = new List<GravityField>();
        foreach(GravityField field in GravityField.allFields)
        {
            if (field.InField(position))
                foundGravitys.Add(field);
        }

        //if fitting grav field hasnt been found, return default grav
        if (foundGravitys.Count <= 0)
            output = Vector3.down;
        else
        {
            foreach(GravityField field in foundGravitys)
            {
                Vector3 v3 = field.getGravityDir(position);
                output += v3 / v3.magnitude * field.Strength(position);
            }
        }

        return output;
    }
}
