using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclMatchingStrategy : IShapeMatchingStrategy
{
    public bool Match(GameObject otherShape)
    {
        // Logic to match circle shapes
        return otherShape.CompareTag("Circle");
    }
}
