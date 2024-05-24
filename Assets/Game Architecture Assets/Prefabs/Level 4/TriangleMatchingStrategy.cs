using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMatchingStrategy : IShapeMatchingStrategy
{
    public bool Match(GameObject otherShape)
    {
        return otherShape.CompareTag("Circle");
    }
}
