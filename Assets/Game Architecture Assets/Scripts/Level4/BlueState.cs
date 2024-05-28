using UnityEngine;

public class BlueState : IState
{
    public void Handle(Cube context)
    {
        context.SetState(new RedState());
    }

    public Color GetColor()
    {
        return Color.blue;
    }
}
