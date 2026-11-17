using UnityEngine;
using UnityEngine.Pool;

public class RecPrisEnemyPool : Singleton<RecPrisEnemyPool>
{
    public int maxPoolSize;
    public int stackDefaultCapacity;
    public GameObject recPrisEnemyPrefab;

    private IObjectPool<EnemyRecPris> _pool;
    public IObjectPool<EnemyRecPris> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<EnemyRecPris>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, stackDefaultCapacity, maxPoolSize);
            }

            return _pool;
        }
    }

    private EnemyRecPris CreatePooledItem()
    {
        EnemyRecPris spawnedRecPrisEnemy = Instantiate(recPrisEnemyPrefab).GetComponent<EnemyRecPris>();
        spawnedRecPrisEnemy.Pool = this.Pool;
        return spawnedRecPrisEnemy;
    }

    void OnReturnedToPool(EnemyRecPris _recPrisEnemy)
    {
        _recPrisEnemy.gameObject.SetActive(false);
    }

    void OnTakeFromPool(EnemyRecPris _recPrisEnemy)
    {
        _recPrisEnemy.gameObject.SetActive(true);
    }

    void OnDestroyPoolObject(EnemyRecPris _recPrisEnemy)
    {
        Destroy(_recPrisEnemy.gameObject);
    }
}
