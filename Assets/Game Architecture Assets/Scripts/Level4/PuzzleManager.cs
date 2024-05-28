using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    public Cube[] cubes;
    public Color[] targetPattern;

    public UnityEvent OnPuzzleSolved;
    public TextMeshProUGUI patternText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        SetPatternText();
    }

    public void CheckPuzzleState()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i].GetColor() != targetPattern[i])
            {
                Debug.Log("Level 4 : Puzzle not solved yet.");
                return;
            }
        }
        Debug.Log("Level 4 : Puzzle Solved");
        OnPuzzleSolved?.Invoke();
    }

    private void SetPatternText()
    {
        patternText.text = "";
        for (int i = 0; i < targetPattern.Length; i++)
        {
            if (targetPattern[i] == Color.red)
            {
                patternText.text += "R";
            }
            else if (targetPattern[i] == Color.green)
            {
                patternText.text += "G";
            }
            else if (targetPattern[i] == Color.blue)
            {
                patternText.text += "B";
            }
            else
            {
                patternText.text += "";
            }
        }
    }
}
