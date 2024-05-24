using UnityEngine;

public class ColorAssigner : MonoBehaviour
{
    void Start()
    {
        AssignRandomColors(transform);
    }

    void AssignRandomColors(Transform parent)
    {
        Color[] distinctColors = { Color.red, Color.magenta, Color.blue, Color.yellow };
        bool[] assigned = new bool[distinctColors.Length];
        Renderer[] renderers = parent.GetComponentsInChildren<Renderer>(true);
        foreach (Renderer renderer in renderers)
        {
            if (renderer.gameObject != parent.gameObject)
            {
                int index = Random.Range(0, distinctColors.Length);
                while (assigned[index])
                {
                    index = Random.Range(0, distinctColors.Length);
                }
                renderer.material.color = distinctColors[index];
                assigned[index] = true;
            }
        }
    }
}
