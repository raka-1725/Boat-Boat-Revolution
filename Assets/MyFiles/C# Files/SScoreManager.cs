using UnityEngine;

public class SScoreManager : MonoBehaviour
{
    public static SScoreManager ScoreInstance { get;  private set; }

    public int Score { get; private set; }
    public int ComboCount { get; private set; }

    private void Awake()
    {
        if (ScoreInstance != null && ScoreInstance != this)
        {
            Destroy(gameObject);
            return;
        }

        ScoreInstance = this;
        DontDestroyOnLoad(gameObject);
        
        ResetComboCount();
        ResetScore();
    }

    public void AddScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        Debug.Log($"Score {Score}");
    }

    public void AddCombo(int comboToAdd)
    {
        ComboCount += comboToAdd;
    }

    public void ResetScore()
    {
        Score = 0;
    }
    
    public void ResetComboCount()
    {
        ComboCount = 0;
    }
}
