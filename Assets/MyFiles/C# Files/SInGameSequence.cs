using System;
using UnityEngine;
using UnityEngine.Video;

public class SInGameSequence : MonoBehaviour
{
    [SerializeField] private VideoPlayer VP_Normal;
    [SerializeField] private VideoPlayer VP_High;

    private GameObject VPNormalGameObject;
    private GameObject VPHighGameObject;

    [SerializeField] private int ComboStreakThreshold = 20;

    private void Start()
    {
        VPNormalGameObject = VP_Normal.gameObject;
        VPHighGameObject = VP_High.gameObject;
        
        VPNormalGameObject.SetActive(true);
        VPHighGameObject.SetActive(false);
        
        VP_Normal.Play();
    }

    private void Update()
    {
        if (SScoreManager.ScoreInstance.ComboCount > ComboStreakThreshold)
        {
            ChangeMicky(true);
        }
        else
        {
            ChangeMicky(false);
        }
    }

    void ChangeMicky(bool bHigh)
    {
        if (bHigh)
        {
            VPNormalGameObject.SetActive(false);
            VPHighGameObject.SetActive(true);
            
            VP_Normal.Stop();
            VP_High.Play();
        }
        else
        {
            VPNormalGameObject.SetActive(true);
            VPHighGameObject.SetActive(false);
            
            VP_High.Stop();
            VP_Normal.Play();
        }
    }
}
