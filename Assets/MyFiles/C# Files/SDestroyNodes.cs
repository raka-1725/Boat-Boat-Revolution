using UnityEngine;

public class SDestroyNodes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            Destroy(other.gameObject);
            Debug.Log($"Note destroy");
        }
    }
}
