using System;
using UnityEngine;

public class SDestroyNodes : MonoBehaviour
{
    private SUIManager UIManager;
    private void Start()
    {
        UIManager = FindAnyObjectByType<SUIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            //Debug.Log($"Missed Note Destroyed ");
            SScoreManager.ScoreInstance.AddScore(-10);
            SScoreManager.ScoreInstance.ResetComboCount();
            UIManager.UpdateHitResultText("MISS");
            Destroy(other.gameObject);
            //Debug.Log($"Note destroy");
        }
    }
}
