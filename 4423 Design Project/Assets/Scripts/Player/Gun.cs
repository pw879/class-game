using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]private Transform robot;

    [Header("Projectile Type")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject chargedShot1;
    [SerializeField] private GameObject chargedShot2;
    [SerializeField] private GameObject chargedShot3;
    

    [Header("Firing Direction Transforms")]
    [SerializeField] private Transform fireRight;
    [SerializeField] private Transform fireLeft;
    [SerializeField] private Transform fireUp;
    [SerializeField] private Transform fireDown;

    [Header("Charge level animations")]
    [SerializeField] private GameObject charge1;
    [SerializeField] private GameObject charge2;
    [SerializeField] private GameObject charge3;

    
    //assigned at start()
    private GameObject shot;
    private GameObject shotFired;

    private Animator animator;

    [Header("Variables defining charge behavior")]
    [SerializeField] private float chargeSpeed;
    public float chargeTime;

    //boolean flags
    private bool isCharging;
    private bool lv1Charged;
    private bool lv2Charged;
    private bool lv3Charged;

    void Start(){
        animator = gameObject.GetComponent<Animator>();
        shotFired = new GameObject();
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && chargeTime < 6){
            isCharging = true;
            if(isCharging == true){
                chargeTime += Time.deltaTime * chargeSpeed;
            }
        }
        if(Input.GetButtonUp("Fire1") && chargeTime < 2){
            chargeTime = 0;
        }
        SetChargeAnimation(chargeTime);
        if(Input.GetButtonUp("Fire1") && chargeTime >= 2 ){
            releaseCharge(shotFired);
            charge1.SetActive(false);
            charge2.SetActive(false);
            charge3.SetActive(false);
        }
    }

    void SetChargeAnimation(float chargetime){
        
        if(chargetime >= 2){
            charge1.SetActive(true);
            shotFired = chargedShot1;
        }
        if(chargetime >= 4){
            charge1.SetActive(false);
            charge2.SetActive(true);
            shotFired = chargedShot2;
        }
        if(chargetime >=6){
            charge2.SetActive(false);
            charge3.SetActive(true);
            shotFired = chargedShot3;
        }
    }

    

    //FIXME write function, determine charge level

    void releaseCharge(GameObject chargedShot){
        float x = animator.GetFloat("LastMoveX");
        float y = animator.GetFloat("LastMoveY");
        if(x == 0 && y > 0){
            shot = Instantiate(chargedShot, fireUp.position, fireUp.rotation);
        }
        if(x == 0 && y < 0){
            shot = Instantiate(chargedShot, fireDown.position, fireDown.rotation);
        }
        if(x > 0 && y == 0){
            shot = Instantiate(chargedShot, fireRight.position, fireRight.rotation);
        }
        if(x < 0 && y == 0){
            shot = Instantiate(chargedShot, fireLeft.position, fireLeft.rotation);
        }
        Destroy(shot, 5f);
        isCharging = false;
        chargeTime = 0;
    }

}
