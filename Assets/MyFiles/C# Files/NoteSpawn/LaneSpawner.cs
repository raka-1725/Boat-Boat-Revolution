using UnityEngine;
using UnityEngine.Playables;

public class LaneSpawner : MonoBehaviour, INotificationReceiver
{
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        spawnPoint = this.gameObject.transform;
    }

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is SpawnNoteMarker marker)
            SpawnPrefab(marker.NotePrefab);
    }

    public void SpawnPrefab(GameObject prefab)
    {
        if (prefab == null) return;
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
