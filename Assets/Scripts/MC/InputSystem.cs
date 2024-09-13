using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    PlayerInputActions inputActions;
    public static event Action onJump;
    public static event Action goingLeft;
    public static event Action onIdle;
    public static event Action goingRight;
    public static event Action goingDown;
    public static event Action goingUp;

    private void Start(){
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
        inputActions.Player.Jump.performed += Jump;
        inputActions.Player.Walking.performed += Movement;
        inputActions.Player.Walking.canceled += Idle;
    }
    private void OnEnable(){
    }

    public void Jump(InputAction.CallbackContext context){
        onJump.Invoke();
    }

    public void Idle(InputAction.CallbackContext context){
        onIdle.Invoke();
    }

    public void Movement(InputAction.CallbackContext context){
        Vector2 move = context.ReadValue<Vector2>();

        if(move.x>0){
            	goingRight.Invoke();
        }

        if(move.x<0){
            	goingLeft.Invoke();
        }

        if(move.y>0){
            	goingDown.Invoke();
        }

        if(move.y<0){
            	goingUp.Invoke();
        }
    }
}
