using UnityEngine;

public class GameManager : Singleton<GameManager>
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
