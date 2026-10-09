using System;
using UnityEngine;

public class SGameManager : MonoBehaviour
{
    private int score = 0;
    private int combo = 0;

    [SerializeField] private int ScoreThreshold = 100;
    
    [SerializeField] private SUIManager UIManager;

    private void Awake()
    {
        UIManager = FindObjectOfType<SUIManager>();
    }

    public void OnSongEnd()
    {
        Debug.Log("OnSongEnd");
        score = SScoreManager.ScoreInstance.Score;
        combo = SScoreManager.ScoreInstance.ComboCount;

        if (score > ScoreThreshold)
        {
            UIManager.SpawnWinUI(score, combo);
        }
        else
        {
            UIManager.SpawnLoseUI(score, combo);
        }
    }
}
