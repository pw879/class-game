using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public bool isWalking;
    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;
    private Animator animator;
    Vector2 movement;

    public bool canMove;

    private int walkDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        canMove = true;
        ChooseDirection();

    }

    // Update is called once per frame
    void Update(){
        if(!DialogManager.instance.dialogBox.activeInHierarchy){
            canMove = true;
        }
        if(!canMove){
            rb.velocity = Vector2.zero;
            return; // cancel out of entire loop
        }
        if(isWalking){
            walkCounter -= Time.deltaTime;

            switch(walkDirection){
                case 0:
                        rb.velocity = new Vector2(0,moveSpeed);
                    break;
                case 1:
                        rb.velocity = new Vector2(moveSpeed,0);
                    break;
                case 2:
                        rb.velocity = new Vector2(0,-moveSpeed);
                    break;
                case 3:
                        rb.velocity = new Vector2(-moveSpeed,0);
                    break;
            }
            movement.x = rb.velocity.x;
            movement.y = rb.velocity.y;
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

            if(rb.velocity.x == moveSpeed ||
            rb.velocity.x == -moveSpeed ||
            rb.velocity.y == moveSpeed ||
            rb.velocity.y == -moveSpeed) {
                // if we are pressing right then last move set to one
                animator.SetFloat("LastMoveX", rb.velocity.x * .005f);
                animator.SetFloat("LastMoveY", rb.velocity.y * .005f);
            }
            //animator.SetFloat("Speed", movement.sqrMagnitude); 
                if(walkCounter < 0){
                    isWalking = false;
                    waitCounter = waitTime; 
                }
        } else {
            waitCounter -= Time.deltaTime;
            rb.velocity =  Vector2.zero;
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            if(waitCounter < 0 ){
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection(){
        walkDirection = Random.Range(0, 4);
        isWalking = true; 
        walkCounter = walkTime; 
    }
}
