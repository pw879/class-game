using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] 
    private float speed;
    [SerializeField] 
    private Rigidbody2D rb;
    [SerializeField] 
    private float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("DestroyProjectile", lifetime);
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }


}
