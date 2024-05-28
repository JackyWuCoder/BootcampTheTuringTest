using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    public Color[] targetPattern;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
    }

    public void CheckPuzzleState()
    {
        Cube[] cubes = FindObjectsOfType<Cube>();
        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i].GetColor() != targetPattern[i])
            {
                Debug.Log("Puzzle not solved yet.");
                return;
            }
        }
        Debug.Log("Puzzle Solved");
        // Implement puzzle solved logic here.
    }
}
