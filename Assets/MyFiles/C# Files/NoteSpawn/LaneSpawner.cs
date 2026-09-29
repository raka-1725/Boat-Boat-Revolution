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
            SpawnPrefab(marker.NotePrefab, marker.NoteType);
    }

    public void SpawnPrefab(GameObject prefab, SNote.ENoteType noteType)
    {
        if (prefab == null) return;
        GameObject Note = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        Note.GetComponent<SNote>().NoteType = noteType;

    }
}
