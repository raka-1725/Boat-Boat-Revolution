using System;
using UnityEngine;

public class SNote : MonoBehaviour
{
    private Rigidbody rb;
    //Default and normal adds 10, high adds 20
    public enum ENoteType
    {
        Default,
        Normal,
        High
    }

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        
        rb.AddForce(Vector3.back, ForceMode.Impulse);
    }
}
