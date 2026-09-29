using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SpawnNoteMarker : Marker, INotification
{
    public GameObject NotePrefab;
    public PropertyName id => new PropertyName("SpawnNote");
}
