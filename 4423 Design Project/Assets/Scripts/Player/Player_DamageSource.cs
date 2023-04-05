using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DamageSource : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.GetComponent<Enemy_Health>()){
            Enemy_Health enemyHealth = other.gameObject.GetComponent<Enemy_Health>();
            enemyHealth.TakeDamage(damageAmount);
        }
    }

}
