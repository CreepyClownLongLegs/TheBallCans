using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : PersistentSingleton<InputSystem>
{
    PlayerInputActions inputActions;
    public static event Action onJump;
    public static event Action goingLeft;
    public static event Action onIdle;
    public static event Action goingRight;
    public static event Action goingDown;
    public static event Action goingUp;
    public static event Action interactPressed;

    bool interactPressedToo = false;
    bool submitPressed = false;


    private void Start(){
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
        inputActions.Player.Jump.performed += Jump;
        inputActions.Player.Walking.performed += Movement;
        inputActions.Player.Walking.canceled += Idle;
        inputActions.Player.Interact.performed += Interact;
    }
    private void OnEnable(){
    }

    private void Interact(InputAction.CallbackContext context){
        interactPressed.Invoke();
        InteractButtonPressed(context);
    }

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed && !DialogueManager.Instance.dialogueIsPlaying)
        {
            interactPressedToo = true;
        }
        else if (context.canceled)
        {
            interactPressedToo = false;
        } 
    }

    public bool GetInteractPressed() 
    {
        bool result = interactPressedToo;
        interactPressedToo = false;
        return result;
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

        public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        } 
    }

        public bool GetSubmitPressed() 
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }

    public void RegisterSubmitPressed() 
    {
        submitPressed = false;
    }
}
