﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private void Update()
    {
        Vector3 pos = transform.position;
        Debug.DrawLine(pos, pos + checkForGravity(pos).normalized);
    }
    public Vector3 checkForGravity(Vector3 position)
    {
        Vector3 output;
        int idx = 0;
        bool foundGravity = false;
        while(idx < GravityField.allFields.Count && !foundGravity)
        {
            foundGravity = GravityField.allFields[idx].InField(position);
            idx++;
        }

        //if fitting grav field hasnt been found, return default grav
        if (!foundGravity)
            output = Vector3.down;
        else
            output = GravityField.allFields[idx - 1].getGravityDir(position);

        return output;
    }
}
