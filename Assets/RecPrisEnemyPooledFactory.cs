using UnityEngine;

public class RecPrisEnemyPooledFactory : MonoBehaviour
{
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
        EnemyRecPris spawnedEnemy = RecPrisEnemyPool.Instance.Pool.Get();

        spawnedEnemy.transform.position = new Vector3(Random.Range(-14f, 14f), 1, Random.Range(-14f, 14f));

        spawnedEnemy.CustomStart();
    }
}
