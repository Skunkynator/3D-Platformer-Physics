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
        float Xinput = Input.GetAxisRaw("Horizontal");
        float Yinput = Input.GetAxisRaw("Vertical");
        Vector2 directionalInput = new Vector2(Xinput, Yinput);
        if(directionalInput != Vector2.zero)
            directionalInput *= (Mathf.Abs(Xinput) < Mathf.Abs(Yinput) ? Mathf.Abs(Yinput) : Mathf.Abs(Xinput)) / directionalInput.magnitude; ;
        player.SetDirectionalInput(directionalInput);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.jump();
        }
    }
}