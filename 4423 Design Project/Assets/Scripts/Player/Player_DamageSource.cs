using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DamageSource : MonoBehaviour
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

        currentDamage = damageAmount + ps.currentAttack;
        
        if (other.gameObject.GetComponent<Enemy_Health>()){
            Enemy_Health enemyHealth = other.gameObject.GetComponent<Enemy_Health>();
            if(sfxMan){
            sfxMan.enemyHurt.Play();
            }
            enemyHealth.TakeDamage(currentDamage);
        }
    }

}
