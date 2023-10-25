using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : MonoBehaviour
{

    private Vector2 input;
    PlayerInputActions inputActions;
    private void Awake()
    {
        inputActions = new PlayerInputActions();

        inputActions.Player.Movement.performed += Movement_performed;
        inputActions.Enable();
    }

    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        input = inputActions.Player.Movement.ReadValue<Vector2>().normalized;
    }

    public float HorizontalInput()
    {
        return input.x;
    }
}
