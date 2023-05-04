using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoMovement : MonoBehaviour
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


    public bool shouldChase;
    public bool isChasing;
    public float chaseSpeed;
    public float rangeToChase;
    public float waitAfterHitting;
    private Transform target;

    public bool canMove;
    private int walkDirection;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("XENO SCRIPT STARTED");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("MyPlayer").transform;
        waitCounter = waitTime;
        walkCounter = walkTime;
        canMove = true;
        ChooseDirection();

    }

    // Update is called once per frame
    void Update(){
        if(!isChasing){
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
                // chase the player
                if(shouldChase){
                    if(Vector2.Distance(target.position, gameObject.transform.position) <= rangeToChase){
                    Debug.Log("CHASING PLAYER");
                    waitCounter = 0;
                    isChasing = true;
                    }
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
        } else{ //chasing is true
            if(waitCounter > 0 ){
                waitCounter -= Time.deltaTime;
                rb.velocity = Vector2.zero;
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 0);
            }else{
                if(Vector2.Distance(target.position, gameObject.transform.position) >= rangeToChase){
                    isChasing = false;
                }else{
                    FollowPlayer();
                }
            }
        }
    }
    

    public void FollowPlayer(){
    transform.position = Vector2.MoveTowards(transform.position, target.position, chaseSpeed * Time.deltaTime);
                    animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
    }

    public void ChooseDirection(){
        walkDirection = Random.Range(0, 4);
        isWalking = true; 
        walkCounter = walkTime; 
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "MyPlayer"){
            Debug.Log("COLLISION DETECTED");

            waitCounter = waitAfterHitting;
            
        }
    }
}
