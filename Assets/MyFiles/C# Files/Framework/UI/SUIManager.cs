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
    
    [Header("Status Bar")]
    [SerializeField] private Slider StatusSlider;

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
        StartCoroutine(GameEndSequence(WinUI, true));
    }

    public void SpawnLoseUI(int score, int combo)
    {
        WinUI.SetActive(false);
        LoseUI.SetActive(true);
        StartCoroutine(GameEndSequence(LoseUI,  false));
    }

    private IEnumerator Fade(float targetA, Image imageComp, float fadeDuration)
    {
        Color color = imageComp.color;
        
        color.a = 0f;
        imageComp.color = color;

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            color.a = Mathf.Lerp(0f, targetA, elapsed / fadeDuration);
            imageComp.color = color;

            yield return null;
        }

        color.a = targetA;
        imageComp.color = color;
    }

    private IEnumerator GameEndSequence(GameObject StateUI, bool bWin)
    {
        SGameEndUI UI = StateUI.GetComponent<SGameEndUI>();

        if (bWin)
        {
            yield return StartCoroutine(Fade(1f, WinUI.GetComponent<Image>(), 1.2f));
        }
        else
        {
            yield return StartCoroutine(Fade(1f, LoseUI.GetComponent<Image>(), 1.2f));
        }
        
        yield return new WaitForSeconds(0.3f);
        
        UI.ActiveContent(true);
        yield return new WaitForSeconds(0.3f);
        UI.PlayVideo(true);
        
        TextMeshProUGUI Score = UI.GetScoreText();
        TextMeshProUGUI Combo = UI.GetComboText();

        Score.text = "Score: " + SScoreManager.ScoreInstance.Score;
        Combo.text = "Combo: " + SScoreManager.ScoreInstance.ComboCount;
        
        yield return null;
    }

}
