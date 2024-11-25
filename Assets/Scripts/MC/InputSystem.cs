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
    public static event Action inventoryCalled;
    public static event Action leftClicked;
    public static event Action rightClicked;
    public static event Action phoneCalled;

    public static event Action leftArrowClicked;
    public static event Action leftArrowCanceled;

    public static event Action rightArrowClicked;
    public static event Action rightArrowCanceled;

    public static event Action downArrowClicked;
    public static event Action downArrowCanceled;

    public static event Action upArrowClicked;
    public static event Action upArrowCanceled;

    bool interactPressedToo = false;
    bool submitPressed = false;


    private void Start(){
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
        inputActions.Player.Jump.performed += Jump;
        inputActions.Player.Walking.performed += Movement;
        inputActions.Player.Walking.canceled += Idle;
        inputActions.Player.Interact.performed += Interact;
        inputActions.Player.Inventory.performed += Inventory;
        inputActions.Player.RightClick.performed += RightClick;
        inputActions.Player.LeftClick.performed += LeftClick;
        inputActions.Player.Phone.performed += phoneIsCalled;
        inputActions.Player.leftArrow.performed += LeftArrowClicked;
        inputActions.Player.leftArrow.canceled += LeftArrowCanceled;
        inputActions.Player.rightArrow.performed += RightArrowClicked;
        inputActions.Player.rightArrow.canceled += RightArrowCanceled;
        inputActions.Player.upArrow.performed += UpArrowClicked;
        inputActions.Player.upArrow.canceled += UpArrowCanceled;
        inputActions.Player.downArrow.performed += DownArrowClicked;
        inputActions.Player.downArrow.canceled += DownArrowCanceled;
    }

    private void DownArrowCanceled(InputAction.CallbackContext context)
    {
        downArrowClicked?.Invoke();
    }

    private void DownArrowClicked(InputAction.CallbackContext context)
    {
        downArrowCanceled?.Invoke();
    }

    private void UpArrowCanceled(InputAction.CallbackContext context)
    {
        upArrowClicked?.Invoke();
    }

    private void UpArrowClicked(InputAction.CallbackContext context)
    {
        upArrowCanceled?.Invoke();
    }

    private void LeftArrowCanceled(InputAction.CallbackContext context)
    {
        leftArrowClicked?.Invoke();
    }

    private void LeftArrowClicked(InputAction.CallbackContext context)
    {
        leftArrowCanceled?.Invoke();
    }

    private void RightArrowCanceled(InputAction.CallbackContext context)
    {
        rightArrowClicked?.Invoke();
    }

    private void RightArrowClicked(InputAction.CallbackContext context)
    {
        rightArrowCanceled?.Invoke();
    }



    private void LeftClick(InputAction.CallbackContext context)
    {
        leftClicked?.Invoke();
    }
    private void phoneIsCalled(InputAction.CallbackContext context)
    {
        phoneCalled?.Invoke();
    }
    private void RightClick(InputAction.CallbackContext context)
    {
        rightClicked?.Invoke();
    }

    private void Interact(InputAction.CallbackContext context){
        interactPressed?.Invoke();
        InteractButtonPressed(context);
    }

    private void Inventory(InputAction.CallbackContext context){
        inventoryCalled?.Invoke();
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
