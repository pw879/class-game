using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "MyPlayer"){
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageAmount);
        }
    }

}
