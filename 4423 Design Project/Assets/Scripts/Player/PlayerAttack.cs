using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    public float attackRange;
    public float attackRangeWidth;
    public float attackRangeLength;
    public LayerMask whatIsEnemy;
    public int damage;
    private Animator animator;

    // Start is called before the first frame update
    void Update()
    {
        //if(timeBetweenAttack <= 0){
            //then you can attack
         //   if(Input.GetButtonDown("Fire1")){
                //animator = GetComponent<Animator>();
         //       //if(animator.GetBool("isAttacking") == true){
         //       Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(firePoint.position, new Vector2(attackRangeWidth, attackRangeLength), 0, whatIsEnemy );
         //       for (int i = 0; i < enemiesToDamage.Length; i++){
                    //enemiesToDamage[i].GetComponent<Enemy>().Health -= damage; 
                    
         //       }
         //   //}
        //    }
        //    timeBetweenAttack = startTimeBetweenAttack;

        //} else {
        //    timeBetweenAttack -= Time.deltaTime;
        //}
        
    }


}
