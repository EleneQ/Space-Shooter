using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    public static GameSession instance;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    //public int GetScore() { return score; }

    //public void AddScore(int scoreValue)
    //{
    //    score += scoreValue;
    //}

    //public void ResetGame()
    //{
    //    Destroy(gameObject);
    //}
}
