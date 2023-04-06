using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float attackTime = .15f;
    private float attackCounter = .33f;
    private bool isAttacking;

    //public bool isKnockingBack;
    //public float knockBackTime, knockBackForce;
    //private float knockBackCounter;
    //private Vector2 knockDir;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;


    // Update is called once per frame
    void Update()
    {
        //Input Handled here
        //if(!isKnockingBack){
            if(!DialogManager.instance.dialogBox.activeInHierarchy){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude); 

            if(Input.GetAxisRaw("Horizontal") == 1 ||
            Input.GetAxisRaw("Horizontal") == -1 ||
            Input.GetAxisRaw("Vertical") == 1 ||
            Input.GetAxisRaw("Vertical") == -1) {
                // if we are pressing right then last move set to one
                animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            }

            if(isAttacking){
                rb.velocity = Vector2.zero;
                attackCounter -= Time.deltaTime;
                if(attackCounter <= 0){
                    animator.SetBool("isAttacking", false);
                    isAttacking = false;
                }
            }

            if(Input.GetButtonDown("Fire1")){
                attackCounter = attackTime;
                animator.SetBool("isAttacking", true);
                if(animator.GetBool("isAttacking") == true){
                    Debug.Log("Bool is Attack");
                }
                isAttacking = true;
            }
            } else{
                rb.velocity = Vector2.zero;
                animator.SetFloat("Speed", 0);
            }
        //} else{
            //knockBackCounter -= Time.deltaTime;
            //rb.velocity = knockDir * knockBackForce;
            //if (knockBackCounter <= 0){
           //     isKnockingBack = false;
           // }
        //}
    }

    //public void knockBack(Vector2 knockerPosition){
    //    knockBackCounter = knockBackTime;
    //    isKnockingBack = true;
    //    knockDir = knockerPosition - new Vector2(transform.position.x, transform.position.y);
    //    knockDir.Normalize();
        //find the enemy that is knocking you back to determine the direction

    //}

    //Move Player with Physics, executed on a fixed timer
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

}
