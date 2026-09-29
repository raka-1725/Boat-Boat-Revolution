using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SpawnNoteMarker : Marker, INotification
{
    public GameObject NotePrefab;
    public SNote.ENoteType NoteType = SNote.ENoteType.Normal;
    public PropertyName id => new PropertyName("SpawnNote");
}
