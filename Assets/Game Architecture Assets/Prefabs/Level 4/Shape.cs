using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private IShapeMatchingStrategy matchingStrategy;

    public void SetMatchingStrategy(IShapeMatchingStrategy strategy)
    {
        matchingStrategy = strategy;
    }

    public bool MatchShape(GameObject otherShape)
    {
        if (matchingStrategy != null)
        {
            return matchingStrategy.Match(otherShape);
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
