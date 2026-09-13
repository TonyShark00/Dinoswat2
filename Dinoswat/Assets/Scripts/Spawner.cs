using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 1f;

    private float timeUntilObstacleSpawn;
    private GameObject lastSpawned;

    private void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn;
        int attempts = 0;

        do
        {
            obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            attempts++;
        }
        while (obstacleToSpawn == lastSpawned && attempts < 10 && obstaclePrefabs.Length > 1);

        lastSpawned = obstacleToSpawn;

        GameObject spawnObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        Rigidbody2D obstacleRB = spawnObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.linearVelocity = Vector2.left * obstacleSpeed;
    }
}
