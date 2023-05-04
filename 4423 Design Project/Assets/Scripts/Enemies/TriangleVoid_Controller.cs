using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleVoid_Controller : MonoBehaviour
{

    private Animator myAnim;
    private Transform target;
    [SerializeField] // still private but you can change it in the editor
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;

    // Start is called before the first frame update
    void Start()
    {
       myAnim = GetComponent<Animator>(); //gets animator component of this gameObject
       target = GameObject.FindWithTag("MyPlayer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange ){
        FollowPlayer();
        }
    }

    public void FollowPlayer(){
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
