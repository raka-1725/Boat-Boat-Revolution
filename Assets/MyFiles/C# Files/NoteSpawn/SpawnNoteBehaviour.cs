using UnityEngine;
using UnityEngine.Playables;

public class SpawnNoteBehaviour : PlayableBehaviour
{
    public GameObject notePrefab;
    
    private bool bHasSpawned = false;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        LaneSpawner spawner = playerData as LaneSpawner;
        
        if (!Application.isPlaying || info.weight <= 0) return;

        if (!bHasSpawned)
        {
            if (spawner != null && notePrefab != null)
            {
                spawner.SpawnPrefab(notePrefab);
            }
            bHasSpawned = true;
        }
    }
    
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        bHasSpawned = false;
    }
}
