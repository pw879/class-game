using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedDroidController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public bool isWalking;
    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;
    private Animator animator;
    private int counter = 0;
    Vector2 movement;

    public bool canMove;

    private int walkDirection;

    
    public float rangeToFire;
    private Transform target;
    public GameObject bullet;
    public float timeBetweenShots;
    private float shotCounter; 
    public Transform shotPoint;

    [Header("cardinal Directions")]
    [SerializeField] private Transform fire0;
    [SerializeField] private Transform fire90;
    [SerializeField] private Transform fire180;
    [SerializeField] private Transform fire270;
    
    [Header("Secondary Directions")]
    [SerializeField] private Transform fire45;
    [SerializeField] private Transform fire135;
    [SerializeField] private Transform fire225;
    [SerializeField] private Transform fire315;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        canMove = true;
        target = GameObject.FindWithTag("MyPlayer").transform;
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
            if(Vector2.Distance(target.position, gameObject.transform.position) <= rangeToFire){
            shotCounter -= Time.deltaTime;
            if(shotCounter < 0){
                counter += 1;
                shotCounter = timeBetweenShots;
                if(counter % 2 == 0){
                SpawnProjectilesA();
                } else {
                SpawnProjectilesB();
                }
            }
        }
    }

    public void ChooseDirection(){
        walkDirection = Random.Range(0, 4);
        isWalking = true; 
        walkCounter = walkTime; 
    }

    	void SpawnProjectilesA()
	{
        GameObject fire1 = Instantiate (bullet, fire0.position, fire0.rotation);
        GameObject fire2 = Instantiate (bullet, fire90.position, fire90.rotation);
        GameObject fire3 = Instantiate (bullet, fire180.position, fire180.rotation);
        GameObject fire4 = Instantiate (bullet, fire270.position, fire270.rotation);
	}

    void SpawnProjectilesB(){
        GameObject fire1 = Instantiate (bullet, fire45.position, fire45.rotation);
        GameObject fire2 = Instantiate (bullet, fire135.position, fire135.rotation);
        GameObject fire3 = Instantiate (bullet, fire225.position, fire225.rotation);
        GameObject fire4 = Instantiate (bullet, fire315.position, fire315.rotation);
    }
}
