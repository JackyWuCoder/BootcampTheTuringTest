using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width = 8;
    [SerializeField] private int height = 8;
    [SerializeField] private GameObject tilePrefab;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }
}
