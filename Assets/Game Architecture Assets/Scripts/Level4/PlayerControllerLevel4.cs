using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLevel4 : MonoBehaviour
{
    public float moveDistance = 1f;
    private Stack<ICommand> commandHistory = new Stack<ICommand>();
    private Stack<Vector3> moveHistory = new Stack<Vector3>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.Z)) // Undo move
        {
            UndoMove();
        }
    }

    void Move(Vector3 direction)
    {
        ICommand moveCommand = new MoveCommand(gameObject, direction * moveDistance, moveHistory);
        moveCommand.Execute();
        commandHistory.Push(moveCommand);
    }

    void UndoMove()
    {
        if (commandHistory.Count > 0)
        {
            ICommand lastCommand = commandHistory.Pop();
            lastCommand.Undo();
        }
    }
}
