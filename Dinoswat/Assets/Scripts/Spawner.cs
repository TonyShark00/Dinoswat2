using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime=2f;
    public float obstacleSpeed=1f;

    private float timeUntilObstacleSpawn;

    private void Update(){
        SpawnLoop();
    }

    private void SpawnLoop(){
        timeUntilObstacleSpawn += Time.deltaTime; //slowly increases time

        if(timeUntilObstacleSpawn >= obstacleSpawnTime){
            Spawn();
            timeUntilObstacleSpawn=0f; //stops infinte spawning
        }
    }

    private void Spawn(){
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];  //chooses random obstacle
        GameObject spawnObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        Rigidbody2D obstacleRB = spawnObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.linearVelocity= Vector2.left * obstacleSpeed; //moves obstacle to left
    }
}
