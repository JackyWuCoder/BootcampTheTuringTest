using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedState : IState
{
    public void Handle(Cube context)
    {
        context.SetState(new GreenState());
    }

    public Color GetColor()
    {
        return Color.red;
    }
}
