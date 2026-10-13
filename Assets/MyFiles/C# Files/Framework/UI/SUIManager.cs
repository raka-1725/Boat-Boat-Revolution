using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
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
    [SerializeField] private PlayableDirector PlayableDirector;
    
    [Header("CountDown")]
    [SerializeField] private Image CountDownBG;
    [SerializeField] private TextMeshProUGUI CountDownText;
    
    [Header("PauseMenu")]
    [SerializeField] private GameObject PauseMenu;

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

    private void Update()
    {
        UpdateProgressSliderValue();
    }

    private void UpdateProgressSliderValue()
    {
        float progress = (float) (PlayableDirector.time / PlayableDirector.duration);
        StatusSlider.value = progress;
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

    private void InitializeCountDown()
    {
        CountDownBG.gameObject.SetActive(true);
        CountDownText.gameObject.SetActive(true);
        CountDownText.text = "3";
    }

    public void UpdateCountDown(int count)
    {
        if (count <= 0)
        {
            CountDownText.text = "Go";
            StartCoroutine(CountDownEnd());
        }
        else if( count >= 3)
        {
            InitializeCountDown();
        }
        else
        {
            CountDownText.text = count.ToString();
        }
        
    }

    private IEnumerator CountDownEnd()
    {
        yield return new WaitForSeconds(0.5f);
        CountDownBG.gameObject.SetActive(false);
        CountDownText.gameObject.SetActive(false);
        yield return null;
    }

    public void PauseUI(bool bPause)
    {
        PauseMenu.SetActive(bPause ? true : false);
    }
}
