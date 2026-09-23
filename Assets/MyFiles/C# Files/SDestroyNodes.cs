using UnityEngine;

public class SDestroyNodes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            Debug.Log($"Missed Note Destroyed ");
            SScoreManager.ScoreInstance.AddScore(-10);
            SScoreManager.ScoreInstance.ResetComboCount();
            
            Destroy(other.gameObject);
            //Debug.Log($"Note destroy");
        }
    }
}
