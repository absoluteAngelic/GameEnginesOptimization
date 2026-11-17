using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float moveSpeed;
    GameObject player;
    Vector3 directionToPlayer;

    public void CustomStart()
    {
        player = GameObject.Find("Player");

        directionToPlayer = player.transform.position - this.transform.position;
        directionToPlayer.Normalize();
    }

    void Update()
    {
        this.transform.position += new Vector3(directionToPlayer.x, 0, directionToPlayer.z) * moveSpeed * Time.deltaTime;

        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeHealth(int dmg)
    {
        health -= dmg;
    }

    void Die()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().EnemyKilled();
        Destroy(this.gameObject);
    }
}
