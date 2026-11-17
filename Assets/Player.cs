using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float attackCooldown;
    float attackCooldownTimer;
    [SerializeField] float attackRange;

    void Update()
    {
        attackCooldownTimer += Time.deltaTime;

        if (attackCooldownTimer >= attackCooldown)
        {
            attackCooldownTimer = 0f;
            Attack();
        }
    }

    void Attack()
    {
        Collider[] enemyCollidersInRange = Physics.OverlapSphere(transform.position, attackRange, LayerMask.GetMask("Enemy"));

        for (int i = 0; i < enemyCollidersInRange.Length; i++)
        {
            enemyCollidersInRange[i].gameObject.GetComponent<Enemy>().TakeHealth(damage);
        }
    }
}
