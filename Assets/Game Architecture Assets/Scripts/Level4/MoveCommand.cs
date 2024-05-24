using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private GameObject player;
    private Vector3 direction;
    private Stack<Vector3> moveHistory;

    public MoveCommand(GameObject player, Vector3 direction, Stack<Vector3> moveHistory)
    {
        this.player = player;
        this.direction = direction;
        this.moveHistory = moveHistory;
    }

    public void Execute()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, direction, out hit, 1f))
        {
            if (hit.collider.CompareTag("Block"))
            {
                Vector3 blockNewPosition = hit.collider.transform.position + direction;
                if (IsPositionEmpty(blockNewPosition))
                {
                    moveHistory.Push(player.transform.position);
                    hit.collider.transform.position = blockNewPosition;
                    player.transform.position += direction;
                }
            }
        }
        else
        {
            moveHistory.Push(player.transform.position);
            player.transform.position += direction;
        }
    }

    public void Undo()
    {
        if (moveHistory.Count > 0)
        {
            player.transform.position = moveHistory.Pop();
        }
    }

    private bool IsPositionEmpty(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f);
        return colliders.Length == 0;
    }
}
