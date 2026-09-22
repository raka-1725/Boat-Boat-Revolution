using System;
using UnityEngine;

public class SAccuracyZone : MonoBehaviour
{
    public SAccuracyDetect AccDetect;
    
    [SerializeField] private int laneIndex;
    [SerializeField] private int zoneIndex;

    private void Awake()
    {
        AccDetect = GetComponentInParent<SAccuracyDetect>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Note")) return;
        AccDetect.NoteEntered(laneIndex, zoneIndex, other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Note")) return;
        AccDetect.NoteExited(laneIndex, zoneIndex, other);
    }
}
