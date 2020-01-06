using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Vector3Comparer : IEqualityComparer<Vector3>
{
    public bool Equals(Vector3 x, Vector3 y)
    {
        return x == y;
    }

    public int GetHashCode(Vector3 obj)
    {
        return obj.GetHashCode();
    }
}
