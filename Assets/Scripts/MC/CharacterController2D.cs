using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour, IDataPersistence
{
    Animator animator;
    Rigidbody2D rb;
    [SerializeField] float speed = 0.3f;
    Vector2 motionVector;

    string current_anim = "idlemc";

    private void OnEnable(){
        InputSystem.onJump += Jump;
        InputSystem.goingDown += goingDownAnimation;
        InputSystem.goingUp += goingUpAnimation;
        InputSystem.goingLeft += goingLeftAnimation;
        InputSystem.goingRight += goingRightAnimation;
        InputSystem.onIdle += idleAnimation;
    }   

    private void OnDisable(){
        InputSystem.onJump -= Jump;
        InputSystem.goingDown -= goingDownAnimation;
        InputSystem.goingUp -= goingUpAnimation;
        InputSystem.goingLeft -= goingLeftAnimation;
        InputSystem.goingRight -= goingRightAnimation;
        InputSystem.onIdle -= idleAnimation;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update(){
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical"));
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        move();
        changePlayerAnimation();
    }

    void move(){
        rb.velocity = motionVector*speed;
    }
    
    private void Jump(){
        Debug.Log("Jump");
    }

    void changePlayerAnimation(){

        animator.Play(current_anim);
    }

    void goingDownAnimation(){
        current_anim = "walkingupmc";
    }

    void goingRightAnimation(){
        current_anim = "walkingrightmc";
    }

    void goingLeftAnimation(){
        current_anim = "walkingleftmc";
    }

    void idleAnimation(){
        current_anim = "idlemc";
    }

    void goingUpAnimation(){
        current_anim = "walkingmc";
    }

    public void LoadGame(GameData data)
    {
    }

    public void SaveGame(GameData data)
    {
    }
}
