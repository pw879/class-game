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
    private PlayerStats ps;
    private int currentDamage;
    private SFXManager sfxMan;

    [SerializeField] private int damageToGive = 10;
    // Start is called before the first frame update
    void Start()
    {
        ps = FindObjectOfType<PlayerStats>();
        healthMan = FindObjectOfType<HealthManager>();
        sfxMan = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentDamage = damageToGive - ps.currentDefence;
        if(currentDamage < 0){
            currentDamage = 0;
        }
        if(isTouching){
            waitToHurt -= Time.deltaTime;
            if(waitToHurt <= 0){
                // hurt player
                if(sfxMan){
                sfxMan.playerHurt.Play();
                }
                healthMan.HurtPlayer(currentDamage);
                waitToHurt = 1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.collider.tag == "MyPlayer"){
            // hurt player
            currentDamage = damageToGive - ps.currentDefence;
            if(currentDamage < 0){
                currentDamage = 0;
            }
            if(sfxMan){
            sfxMan.playerHurt.Play();
            }
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(currentDamage);
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
