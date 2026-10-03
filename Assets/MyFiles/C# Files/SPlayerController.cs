using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SPlayerController : MonoBehaviour
{
    private MusicGame_InputActions inputActions;
    [SerializeField] private SAccuracyDetect accDetect;
    [SerializeField] private SKeyPressVisuallizer keyVisuallizer;
    private void Awake()
    {
        inputActions = new MusicGame_InputActions();
        inputActions.Player.Lane1.performed += context => PerformHitNote(context, 1);
        inputActions.Player.Lane2.performed += context => PerformHitNote(context, 2);
        inputActions.Player.Lane3.performed += context => PerformHitNote(context, 3);
        inputActions.Player.Lane4.performed += context => PerformHitNote(context, 4);
        
        inputActions.Player.All_Lane.performed += context => PerformHitNote(context, 0);
        
        inputActions.Player.Lane1.performed += context => KeyPressed(context, 1);
        inputActions.Player.Lane2.performed += context => KeyPressed(context, 2);
        inputActions.Player.Lane3.performed += context => KeyPressed(context, 3);
        inputActions.Player.Lane4.performed += context => KeyPressed(context, 4);
        
        inputActions.Player.Lane1.canceled += context => KeyReleased(context, 1);
        inputActions.Player.Lane2.canceled += context => KeyReleased(context, 2);
        inputActions.Player.Lane3.canceled += context => KeyReleased(context, 3);
        inputActions.Player.Lane4.canceled += context => KeyReleased(context, 4);
        
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

    private void KeyPressed(InputAction.CallbackContext context, int laneIndex)
    {
        keyVisuallizer.OnPressed(laneIndex);
    }

    private void KeyReleased(InputAction.CallbackContext context, int laneIndex)
    {
        keyVisuallizer.OnReleased(laneIndex);
    }
}
