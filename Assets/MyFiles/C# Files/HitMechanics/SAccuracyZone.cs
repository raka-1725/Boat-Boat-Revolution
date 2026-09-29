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
        AccDetect.NoteEntered(laneIndex - 1, zoneIndex - 1, other.GetComponent<SNote>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Note")) return;
        AccDetect.NoteExited(laneIndex - 1, zoneIndex - 1, other.GetComponent<SNote>());
    }
}
