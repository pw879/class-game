using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    //apply to multiple enemies
    public float waitToHurt = 1f;
    public bool isTouching;
    private HealthManager healthMan;

    [SerializeField] private int damageToGive = 10;
    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouching){
            waitToHurt -= Time.deltaTime;
            if(waitToHurt <= 0){
                // hurt player
                healthMan.HurtPlayer(damageToGive);
                waitToHurt = 1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.collider.tag == "MyPlayer"){
            // hurt player
            Debug.Log("Player Injured");
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
            //other.gameObject.GetComponent<PlayerMovement>().knockBack(transform.position);

            //other.gameObject.SetActive(false);
            //.LoadLevel("Main");
        }
    }

    void OnCollisionStay2D(Collision2D other){ 
        if(other.collider.tag == "MyPlayer"){
            isTouching = true;
        }

    }

    void OnCollisionExit2D(Collision2D other){
        if(other.collider.tag == "MyPlayer"){
            isTouching = false;
            waitToHurt = 1f;
        }
    }
}
