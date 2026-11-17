using UnityEngine.Pool;

public class EnemyRecPris : Enemy
{
    public IObjectPool<EnemyRecPris> Pool { get; set; }

    protected override void Die()
    {
        GameManager.Instance.EnemyKilled();
        Pool.Release(this);
    }

    void OnDisable()
    {
        FullReset();
    }

    void FullReset()
    {
        health = 100;
    }
}
