using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

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
        LoseUI.SetActive(false);
        WinUI.SetActive(true);
        StartCoroutine(Fade(1f, WinUI.GetComponent<Image>(), 1.2f));
        GameEndSequence(WinUI);
    }

    public void SpawnLoseUI(int score, int combo)
    {
        WinUI.SetActive(false);
        LoseUI.SetActive(true);
        StartCoroutine(Fade(1f, LoseUI.GetComponent<Image>(), 1.2f));
        GameEndSequence(LoseUI);
    }

    private IEnumerator Fade(float TargetA, Image imageComp, float fadeDuration)
    {
        float currentA = imageComp.color.a;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            
            Color color = imageComp.color;
            color.a = Mathf.Lerp(currentA,TargetA, elapsed/fadeDuration);
            yield return null;
        }
        
        Color finalcolor = imageComp.color;
        finalcolor.a = TargetA;
        imageComp.color = finalcolor;
    }

    private void GameEndSequence(GameObject StateUI)
    {
        SGameEndUI UI = StateUI.GetComponent<SGameEndUI>();
        
        UI.PlayVideo(true);
        UI.ActiveContent(true);
        
        TextMeshProUGUI Score = UI.GetScoreText();
        TextMeshProUGUI Combo = UI.GetComboText();

        Score.text = "Score: " + SScoreManager.ScoreInstance.Score;
        Combo.text = "Combo: " + SScoreManager.ScoreInstance.ComboCount;
    }

}
