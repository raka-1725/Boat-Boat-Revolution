using System;
using UnityEngine;

public class SScoreManager : MonoBehaviour
{
    public static SScoreManager ScoreInstance { get;  private set; }

    public int Score { get; private set; }
    public int ComboCount { get; private set; }
    
    public static event Action<int> OnComboCountChange;
    public static event Action<int> OnScoreChange;

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

        SetUI();
    }

    private void SetUI()
    {

    }

    public void AddScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        OnScoreChange?.Invoke(Score);
        Debug.Log($"Score {Score}");
    }

    public void AddCombo(int comboToAdd)
    {
        ComboCount += comboToAdd;
        OnComboCountChange?.Invoke(ComboCount);
    }

    public void ResetScore()
    {
        Score = 0;
        OnScoreChange?.Invoke(Score);
    }
    
    public void ResetComboCount()
    {
        ComboCount = 0;
        OnComboCountChange?.Invoke(ComboCount);
    }
}
