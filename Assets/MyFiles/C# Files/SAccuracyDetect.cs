using System;
using UnityEngine;

public class SAccuracyDetect : MonoBehaviour
{
    //[lane, zone]
    private SNote[,] activeNotes = new SNote[4,3];
    
    private void Awake()
    {
    }

    public void HitNote(int laneIndex)
    {
        Debug.Log($"Note hit active on lane : {laneIndex}");
    }

    public void NoteEntered(int laneIndex, int zoneIndex, SNote note)
    {
        Debug.Log($"Note entered : Lane {laneIndex} Zone {zoneIndex}");
        
        activeNotes[laneIndex, zoneIndex] = note;
    }

    public void NoteExited(int laneIndex, int zoneIndex, SNote note)
    {
        activeNotes[laneIndex, zoneIndex] = null;
    }
}
