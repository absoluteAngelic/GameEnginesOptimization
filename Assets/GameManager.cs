using UnityEngine;

public class GameManager : MonoBehaviour
{
    int kills;
    [SerializeField] int killsToGet;
    [SerializeField] GameObject winScreen;
    
    void Update()
    {
        if (kills >= killsToGet)
        {
            Win();
        }
    }

    void Win()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void EnemyKilled()
    {
        kills++;
    }
}
