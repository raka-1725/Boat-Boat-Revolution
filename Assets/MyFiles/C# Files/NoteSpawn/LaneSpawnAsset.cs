using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class LaneSpawnAsset : PlayableAsset
{
    public GameObject NotePrefab;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SpawnNoteBehaviour>.Create(graph);
        var behaviour = playable.GetBehaviour();
        behaviour.notePrefab = NotePrefab;
        return playable;
    }
}
