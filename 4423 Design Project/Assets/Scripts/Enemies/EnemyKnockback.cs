using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    //how much force player gives
    public float thrust;
    public float knockTime;

    //check to see if enemy is triggered
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("MyPlayer")){
            //change rigid body system
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null){
                enemy.isKinematic = true;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                Debug.Log(difference);
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
                Debug.Log("Knocked Player Back");
            }
        }
        
    }

    private IEnumerator KnockCo(Rigidbody2D enemy){
        if(enemy != null){
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero; 
            enemy.isKinematic = false;
        }
    }
}
