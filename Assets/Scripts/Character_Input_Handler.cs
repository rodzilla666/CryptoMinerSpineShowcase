using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Input_Handler : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;

    public delegate void OnMove(string state);
    public event OnMove onMove;

    private bool isMovementKeyHeld;

    private void OnEnable()
    {
        var actionMap = inputActions.FindActionMap("AM_Forest_RPG");

        GetInputAction("Move_Right").started += OnMoveRightStarted;
        GetInputAction("Move_Right").canceled += OnMoveCanceled;
        GetInputAction("Move_Right").Enable();

        GetInputAction("Move_Left").started += OnMoveLeftStarted;
        GetInputAction("Move_Left").canceled += OnMoveCanceled;
        GetInputAction("Move_Left").Enable();
    }

    private void OnDisable()
    {
        var actionMap = inputActions.FindActionMap("AM_Forest_RPG");

        GetInputAction("Move_Right").started -= OnMoveRightStarted;
        GetInputAction("Move_Right").canceled -= OnMoveCanceled;
        GetInputAction("Move_Right").Disable();

        GetInputAction("Move_Left").started -= OnMoveLeftStarted;
        GetInputAction("Move_Left").canceled -= OnMoveCanceled;
        GetInputAction("Move_Left").Disable();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("MoveCanceled");
        onMove?.Invoke("Canceled");
    }

    private void OnMoveLeftStarted(InputAction.CallbackContext context)
    {
        Debug.Log("MoveLeft");
        isMovementKeyHeld = true;
        onMove?.Invoke("MoveLeft");
    }

    private void OnMoveRightStarted(InputAction.CallbackContext context)
    {
        Debug.Log("MoveRight");
        isMovementKeyHeld = true;
        onMove?.Invoke("MoveRight");
    }

    private InputAction GetInputAction(string actionName)
    {
        var actionMap = inputActions.FindActionMap("AM_Forest_RPG");
        var action = actionMap.FindAction(actionName);
        return action;
    }
}
