using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject[] goals;

    void Update()
    {
        if (AllBlocksInGoals())
        {
            Debug.Log("Puzzle Solved!");
        }
    }

    private bool AllBlocksInGoals()
    {
        foreach (var goal in goals)
        {
            bool goalFilled = false;
            foreach (var block in blocks)
            {
                if (Vector3.Distance(goal.transform.position, block.transform.position) < 0.1f)
                {
                    goalFilled = true;
                    break;
                }
            }
            if (!goalFilled)
            {
                return false;
            }
        }
        return true;
    }
}
