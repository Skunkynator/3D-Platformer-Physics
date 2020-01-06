using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Player))]
class PlayerInput:MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.jump();
        }
    }
}