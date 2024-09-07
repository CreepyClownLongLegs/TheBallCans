using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    [SerializeField] float speed = 0.3f;
    Vector2 motionVector;

    string current_anim = "idlemc";

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

    void changePlayerAnimation(){

        current_anim = "idlemc";
        
        if(Math.Abs(rb.velocity.x)>0 || Math.Abs(rb.velocity.y)>0){
            current_anim = "walkingmc";
        }

        animator.Play(current_anim);
    }
}
