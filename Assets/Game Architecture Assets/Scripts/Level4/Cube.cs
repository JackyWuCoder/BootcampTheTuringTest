using UnityEngine;

public class Cube : MonoBehaviour
{
    private IState currentState;

    // Start is called before the first frame update
    void Start()
    {
        SetState(new RedState());
    }

    public void SetState(IState state)
    {
        currentState = state;
        GetComponent<Renderer>().material.color = currentState.GetColor();
    }

    public void Request()
    {
        currentState.Handle(this);
    }

    public Color GetColor()
    {
        return currentState.GetColor();
    }
}
