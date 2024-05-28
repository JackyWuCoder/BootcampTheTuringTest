using UnityEngine;

public class GreenState : IState
{
    public void Handle(Cube context)
    {
        context.SetState(new BlueState());
    }

    public Color GetColor()
    {
        return Color.green;
    }
}
