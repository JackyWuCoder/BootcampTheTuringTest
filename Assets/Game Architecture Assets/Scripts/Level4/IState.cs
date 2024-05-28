using UnityEngine;

public interface IState
{
    public void Handle(Cube context);
    public Color GetColor();
}
