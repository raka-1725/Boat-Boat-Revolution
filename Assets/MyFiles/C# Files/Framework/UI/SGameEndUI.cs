using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SGameEndUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI ComboText;
    
    [Header("Visual")]
    [SerializeField] VideoPlayer VP;
    [SerializeField] GameObject Image;
    
    [Header("GameObjet")]
    [SerializeField] GameObject content;

    public void PlayVideo(bool bPlay)
    {
        if (bPlay)
        {
            VP.Play();
        }
        else
        {
            VP.Stop();
        }

    }

    public void ActiveContent(bool bActive)
    {
        content.SetActive(bActive);
        Image.SetActive(bActive);
        Debug.Log(bActive);
    }
    
    public TextMeshProUGUI GetScoreText() => ScoreText;
    public TextMeshProUGUI GetComboText() => ComboText;
}
