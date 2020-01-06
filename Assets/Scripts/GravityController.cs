using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class GravityController : MonoBehaviour
{
    Vector3 prevGrav = Vector3.down;
    Vector3 curGrav;
    Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        Vector3 pos = transform.position;
        curGrav = checkForGravity(pos);
        if (curGrav != prevGrav)
        {
            player.SetGravity(curGrav);
            prevGrav = curGrav;
        }
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

        return output / output.magnitude * 9.8f;
    }
}
