using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] float spawnCooldown;
    float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnCooldown)
        {
            spawnTimer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        Enemy spawnedEnemy = Instantiate(enemyPrefab);

        spawnedEnemy.transform.position = new Vector3(Random.Range(-14f, 14f), enemyPrefab.transform.position.y, Random.Range(-14f, 14f));

        spawnedEnemy.CustomStart();
    }
}
