using System;
using TMPro;
using UnityEngine;

public class SUIManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI ComboText;
    
    [Header("UI")] 
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject LoseUI;


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
    
    public void SpawnWinUI(int score, int combo)
    {
        WinUI.SetActive(true);
        LoseUI.SetActive(false);
    }

    public void SpawnLoseUI(int score, int combo)
    {
        LoseUI.SetActive(true);
        WinUI.SetActive(false);
    }
    
    
}
