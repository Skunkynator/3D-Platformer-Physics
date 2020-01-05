using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace skunky.Fields
{
    public abstract class Field : MonoBehaviour
    {
        public abstract bool collides(Vector3 position);
    }
}
