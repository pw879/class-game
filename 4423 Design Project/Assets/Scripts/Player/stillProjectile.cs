using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stillProjectile : MonoBehaviour
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
        Invoke("DestroyProjectile", lifetime);
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }


}
