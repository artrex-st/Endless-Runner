using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Obstacle[] obstaclePrefabOptions;

    private Obstacle currentObstacle;

    public void SpawnObstacle()
    {
        Obstacle prefab = obstaclePrefabOptions[Random.Range(0, obstaclePrefabOptions.Length)];
        currentObstacle = Instantiate(prefab, transform);
        //TODO: Criar RNG para qual trilha será usada
        currentObstacle.transform.localPosition = Vector3.zero;
        currentObstacle.transform.rotation = Quaternion.identity;
        currentObstacle.SpawnDecorations();
    }
}
