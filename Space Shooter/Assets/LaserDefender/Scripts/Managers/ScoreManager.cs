using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score;
    [SerializeField] int scoreToAdd = 100;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
        scoreText.text = $"Score: {score}";
    }

    public void AddScore()
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }
}
