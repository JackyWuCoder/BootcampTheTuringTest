using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMatchingStrategyt : IShapeMatchingStrategy
{
    public bool Match(GameObject otherShape)
    {
        // Logic to match square shapes
        return otherShape.CompareTag("Square");
    }
}
