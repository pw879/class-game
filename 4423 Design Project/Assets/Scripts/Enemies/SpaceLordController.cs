using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLordController: MonoBehaviour
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

    public GameObject bullet;
    public float timeBetweenShots;
    private float shotCounter; 
    public Transform shotPoint;

    public float rangeToFire;
    private Transform target;
    private int walkDirection;

    [SerializeField] private Transform fire0;
    [SerializeField] private Transform fire90;
    [SerializeField] private Transform fire180;
    [SerializeField] private Transform fire270;

	float radius, shotSpeed;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("MyPlayer").transform;
        waitCounter = waitTime;
        walkCounter = walkTime;
        shotCounter = timeBetweenShots; 
        
        ChooseDirection();
    }

    // Update is called once per frame
    void Update(){
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

            if(rb.velocity.x == moveSpeed ||
            rb.velocity.x == -moveSpeed ||
            rb.velocity.y == moveSpeed ||
            rb.velocity.y == -moveSpeed) {
            }

            if(walkCounter < 0){
                isWalking = false;
                waitCounter = waitTime; 
            }
        } else {
            waitCounter -= Time.deltaTime;
            rb.velocity =  Vector2.zero;
            if(waitCounter < 0 ){
                ChooseDirection();
            }
        }

        if(Vector2.Distance(target.position, gameObject.transform.position) <= rangeToFire){
            shotCounter -= Time.deltaTime;
            if(shotCounter < 0){
                shotCounter = timeBetweenShots;
                SpawnProjectiles();
            }
        }
        // if player is in range fire.
    } 

    public void ChooseDirection(){
        walkDirection = Random.Range(0, 4);
        isWalking = true; 
        walkCounter = walkTime; 
    }

    
	void SpawnProjectiles()
	{
        Debug.Log("FIRE 1");
        GameObject fire1 = Instantiate (bullet, fire0.position, fire0.rotation);
        Debug.Log("FIRE 2");
        GameObject fire2 = Instantiate (bullet, fire90.position, fire90.rotation);
        Debug.Log("FIRE 3");
        GameObject fire3 = Instantiate (bullet, fire180.position, fire180.rotation);
        Debug.Log("FIRE 4");
        GameObject fire4 = Instantiate (bullet, fire270.position, fire270.rotation);
	}
}
