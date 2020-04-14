using UnityEngine;

public class CasketGenerator : MonoBehaviour
{
    [SerializeField] private Casket casketPrefab = null;
    [SerializeField] private float spaceBetweenPrefabs = 3f;
    [SerializeField] private Vector3 center = Vector3.zero;
    [SerializeField] private Vector2Int gridSize = new Vector2Int(5, 5);


    private void Awake()
    {
        GenerateCaskets();
    }

    private void GenerateCaskets()
    {
        Vector3 startPos = new Vector3(center.x - Mathf.Floor(gridSize.x / 2f) * spaceBetweenPrefabs, center.y - Mathf.Floor(gridSize.y / 2f) * spaceBetweenPrefabs, 0f);

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                ObjectPooler.Create(casketPrefab.gameObject, startPos + new Vector3(x * spaceBetweenPrefabs, y * spaceBetweenPrefabs, 1f), Quaternion.identity);
            }
        }

        AstarPath.active.Scan();
    }
}
