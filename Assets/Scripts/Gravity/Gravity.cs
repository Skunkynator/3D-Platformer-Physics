using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace skunky.Gravity
{
    public abstract class Gravity : MonoBehaviour
    {
        abstract public float Strength(Vector3 position);
        public abstract Vector3 getGravityDir(Vector3 position);
    }
}