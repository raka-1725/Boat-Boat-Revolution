using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SPlayerController : MonoBehaviour
{
    private MusicGame_InputActions inputActions;
    [SerializeField] private SAccuracyDetect accDetect;
    private void Awake()
    {
        inputActions = new MusicGame_InputActions();
        inputActions.Player.Lane1.performed += context => PerformHitNote(context, 1);
        inputActions.Player.Lane2.performed += context => PerformHitNote(context, 2);
        inputActions.Player.Lane3.performed += context => PerformHitNote(context, 3);
        inputActions.Player.Lane4.performed += context => PerformHitNote(context, 4);
        
        inputActions.Player.All_Lane.performed += context => PerformHitNote(context, 0);
        
        GetAccDetect();
    }

    private void OnEnable() => inputActions.Player.Enable();
    private void OnDisable() => inputActions.Player.Disable();

    private void GetAccDetect()
    {
        accDetect = GameObject.FindAnyObjectByType<SAccuracyDetect>();
        if(!accDetect){ Debug.Log("accDetect is null");}
    }

    private void PerformHitNote(InputAction.CallbackContext context, int laneIndex)
    {
        if (laneIndex == 0) return;
        accDetect.HitNote(laneIndex);
    }
}
