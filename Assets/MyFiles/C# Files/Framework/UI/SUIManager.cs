using System;
using TMPro;
using UnityEngine;

public class SUIManager : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI ComboText;


    private void OnEnable()
    {
        SScoreManager.OnScoreChange += UpdateScoreUI;
        SScoreManager.OnComboCountChange += UpdateComboUI;
    }

    private void OnDisable()
    {
        SScoreManager.OnScoreChange -= UpdateScoreUI;
        SScoreManager.OnComboCountChange -= UpdateComboUI;
    }

    public void UpdateScoreUI(int score)
    {
        ScoreText.text = "Score: " + score;
    }

    public void UpdateComboUI(int combo)
    {
        ComboText.text = "Combo: " + combo;
    }
}
