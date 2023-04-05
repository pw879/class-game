using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;



    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            //Shoot();
        }
    }

    void Shoot(){
        // Shooting Logic, Profab Shooting Method
        // coroutine
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bulletPrefab, .33f);

    }

}
