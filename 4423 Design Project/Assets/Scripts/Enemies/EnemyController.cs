using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb; 
    public Animator anim;

    public float moveSpeed; 
    public float waitTime;
    public float moveTime;
    private float waitCounter, moveCounter;

    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitTime; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime > 0){
            waitCounter  = waitCounter - Time.deltaTime;
            rb.velocity = Vector2.zero; 
            if(waitCounter <= 0){
                moveCounter = moveTime;
                anim.SetBool("moving", true);
            }
        }
        
    }
}
