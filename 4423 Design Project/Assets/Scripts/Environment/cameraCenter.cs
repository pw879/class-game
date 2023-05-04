using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCenter : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y,transform.position.z );
    }
}
