using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DamageSource : MonoBehaviour
{
    private PlayerStats ps;
    [SerializeField] private int damageAmount = 1;
    private int currentDamage;
    private SFXManager sfxMan;

    void Start(){
        ps = FindObjectOfType<PlayerStats>();
        sfxMan = FindObjectOfType<SFXManager>();
    }
    private void OnTriggerEnter2D(Collider2D other){

        currentDamage = damageAmount + ps.currentDefence;
        
        if (other.tag == "MyPlayer"){
            HealthManager playerHealth = other.gameObject.GetComponent<HealthManager>();
            sfxMan.playerHurt.Play();
            playerHealth.HurtPlayer(currentDamage);
        }
    }

}
