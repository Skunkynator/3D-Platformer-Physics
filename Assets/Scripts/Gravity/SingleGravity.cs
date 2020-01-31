﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace skunky.Gravity
{
    public class SingleGravity : Gravity
    {
        [SerializeField]
        Vector3 direction;
        private void Start()
        {
            //GravityField.gravTypes.Add("single", getGravityDir);
        }
        public override float Strength(Vector3 position)
        {
            return 1;
        }
        public override Vector3 getGravityDir(Vector3 position)
        {
            return direction;
        }
    }
}
