using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start(){
        //rb.velocity = transform.position;
    }

    void OnTriggerEnter2d(Collider2D hitinfo){
        Enemy enemy = hitinfo.GetComponent<Enemy>();
        if (enemy != null){
            enemy.TakeDamage(damage);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(impactEffect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
