using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public VectorValue startingPosition; 
    private float attackTime = .15f;
    private float attackCounter = .33f;
    private bool isAttacking;
    private HealthManager healthMan;


    private Rigidbody2D rb;
    private Animator animator;
    Vector2 movement;
    [Header("Getting currently Equipped Items (Armor, and Weapon)")]
    [SerializeField] private PlayerInventory myInventory;

    [Header("Base Attack Firing Direction Transforms")]
    [SerializeField] private Transform fireRight;
    [SerializeField] private Transform fireLeft;
    [SerializeField] private Transform fireUp;
    [SerializeField] private Transform fireDown;

    [SerializeField] private GameObject currentShot;
    private GameObject myBaseShot;

    void Start(){
        myBaseShot = new GameObject();
    }


    void Awake(){

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthMan = GetComponent<HealthManager>();
        if(!startingPosition.isNotFirstRun){
            transform.position = new Vector2(12.5f,5f);
            startingPosition.currentHealth = 100;
            startingPosition.isNotFirstRun = true;
        } else{
            transform.position = startingPosition.initialValue;
            //transform.position = new Vector2(-3.9f, -5.04f ); //life support
            //transform.position = new Vector2(-12.99f, 3.7f);
            healthMan.currentHealth = startingPosition.currentHealth;
        }
    }
    // Update is called once per frame
    void Update(){
        //Input Handled here
            if(!DialogManager.instance.dialogBox.activeInHierarchy || DialogManager.instance.moveOverride == true){
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
                baseShotFired(myInventory.currentWeapon.baseFire);
                
            }
            } else {
                rb.velocity = Vector2.zero;
                animator.SetFloat("Speed", 0);
            }
    }

    //Move Player with Physics, executed on a fixed timer
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    void baseShotFired(GameObject baseShot){
        float x = animator.GetFloat("LastMoveX");
        float y = animator.GetFloat("LastMoveY");
        if(x == 0 && y > 0){
            myBaseShot = Instantiate(baseShot, fireUp);
        }
        if(x == 0 && y < 0){
            myBaseShot = Instantiate(baseShot, fireDown);
        }
        if(x > 0 && y == 0){
            myBaseShot = Instantiate(baseShot, fireRight);
        }
        if(x < 0 && y == 0){
            myBaseShot = Instantiate(baseShot, fireLeft);
        }
        Destroy(myBaseShot, .5f);
        //isCharging = false;
        //chargeTime = 0;
    }

}

