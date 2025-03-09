using UnityEngine;

public class IslandSpawner : MonoBehaviour
{
    [Header("��")]
    public int spawnIslandCount = 2;
    public float minDistance = 2f; // �� �� �ּ� �Ÿ�
    public Vector2 screenArea;
    public BoxCollider2D spawnCollider;
    [SerializeField] GameObject[] islandPrefabArray = new GameObject[2];
    void Start()
    {
        SpawnIsland();
    }
    void SpawnIsland()
    {
        for (int i = 0; i < spawnIslandCount; i++)
        {
            Vector2 spawnPosition;
            int attempts = 0;
            do
            {
                float x = Random.Range(-spawnCollider.size.x, spawnCollider.size.x);
                float y = Random.Range(-spawnCollider.size.y, spawnCollider.size.y);

                // ���� �������� ��ǥ ����
                spawnPosition = new Vector2(x, y);
                attempts++;
            }
            while (Physics2D.OverlapCircle(spawnPosition, minDistance) != null && attempts < 100);

            if (attempts < 100)
            {
                int randomIdx = Random.Range(0, 2);
                Instantiate(islandPrefabArray[randomIdx], spawnPosition, islandPrefabArray[randomIdx].transform.rotation);
            }
        }
    }

}
