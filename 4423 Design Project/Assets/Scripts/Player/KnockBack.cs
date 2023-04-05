using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    //how much force player gives
    public float thrust;
    public float knockTime;

    public GameObject enemyHitGraphic;
    private GameObject InstObj;



    //check to see if enemy is triggered
    private void OnTriggerEnter2D(Collider2D other){
        
        if (other.gameObject.CompareTag("Enemy")){
            //change rigid body system
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null){
            InstObj = Instantiate(enemyHitGraphic, other.transform.position, other.transform.rotation);
            Destroy(InstObj, .133f);
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
                Debug.Log("Hit Enemy");
            }
        }
      
        
    }

    private IEnumerator KnockCo(Rigidbody2D enemy){
        if(enemy != null){
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero; 
            enemy.isKinematic = true;
        }
    }
}
