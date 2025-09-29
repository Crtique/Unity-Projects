using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] brutePrefab;
    private float spawnRangeX = 7f;
    private float spawnPosZ = 4f;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    private float bruteSpawnInterval = 10.0f;


    private int spawnCount = 5;
    private bool spawning = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
        InvokeRepeating("SpawnBrute", startDelay, bruteSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // Stop spawning when the enemys have reached the spawnCount
        if (currentEnemyCount >= spawnCount && spawning)
        {
            CancelInvoke("SpawnEnemy");
            spawning = false;
        }
        // Restart spawning once enemys have started to die
        else if (currentEnemyCount < spawnCount && !spawning)
        {
            InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
            spawning = true;
        }
    }

    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(enemyPrefab[enemyIndex], spawnPos, enemyPrefab[enemyIndex].transform.rotation);
    }
    void SpawnBrute()
    {
        int bruteIndex = Random.Range(0, brutePrefab.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(brutePrefab[bruteIndex], spawnPos, brutePrefab[bruteIndex].transform.rotation);
    }
}
