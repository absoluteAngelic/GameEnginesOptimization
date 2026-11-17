using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float moveSpeed;
    Vector3 directionToPlayer;

    public void CustomStart()
    {
        directionToPlayer = Player.Instance.transform.position - this.transform.position;
        directionToPlayer.Normalize();
    }

    void Update()
    {
        this.transform.position += new Vector3(directionToPlayer.x, 0, directionToPlayer.z) * moveSpeed * Time.deltaTime;
    }

    public void TakeHealth(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Die();
        }
    }

    virtual protected void Die()
    {

    }
}
