using UnityEngine;

public class PlayerInteractionLevel4 : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3.0f;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                Cube cube = hit.collider.GetComponent<Cube>();
                if (cube != null)
                {
                    cube.Request();
                    PuzzleManager.Instance.CheckPuzzleState();
                }
            }
        }
    }
}
