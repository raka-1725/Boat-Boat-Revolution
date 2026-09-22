using UnityEngine;

public class SDestroyNodes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Note")
        {
            Destroy(other.gameObject);
            Debug.Log($"Note destroy");
        }
    }
}
