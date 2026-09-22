using System;
using UnityEngine;

public class SNote : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5.0f;

    //struct
    public struct NoteInfo
    {
        public ENoteType NoteType { get; private set; }
        public int lane { get; private set; }

        public NoteInfo(int lane, ENoteType noteType)
        {
            this.lane = lane;
            this.NoteType = noteType;
        }
    }

    //Default and normal adds 10, high adds 20
    public enum ENoteType
    {
        Default,
        Normal,
        High
    }

    public ENoteType NoteType;

    public void Initialize(ENoteType type)
    {
        NoteType = type;
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 targetSPD = -transform.forward * speed;

        rb.linearVelocity = new Vector3(targetSPD.x, rb.linearVelocity.y, targetSPD.z);
        
        Debug.Log($"targetSPD: {targetSPD}");
    }
}
