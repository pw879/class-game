using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]private Transform robot;

    [Header("Projectile Type")]
    [SerializeField] private GameObject projectile;
    //[SerializeField] private GameObject noChargeShot;
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

    [Header("Enhanced Pattern transforms")]
    [SerializeField] private Transform fire0;
    [SerializeField] private Transform fire30;
    [SerializeField] private Transform fire60;
    [SerializeField] private Transform fire90;
    [SerializeField] private Transform fire120;
    [SerializeField] private Transform fire150;
    [SerializeField] private Transform fire180;
    [SerializeField] private Transform fire210;
    [SerializeField] private Transform fire240;
    [SerializeField] private Transform fire270;
    [SerializeField] private Transform fire300;
    [SerializeField] private Transform fire330;

    [Header("SoundFX")]
    private SFXManager sfxMan;

    [Header("UI")]
    [SerializeField] private UI_Manager uiMan;
    


    [Header("Reference to player Inventory")]
    [SerializeField] private PlayerInventory myInventory;

    
    //assigned at start()
    private GameObject shot;
    private GameObject shotFired;
    private int pattern;

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
        robot = gameObject.transform;
        shotFired = new GameObject();
        pattern = 0;
        sfxMan = FindObjectOfType<SFXManager>();
        uiMan = FindObjectOfType<UI_Manager>();



    }

    void Update()
    {
        if(Input.GetButton("Fire1") && chargeTime < 6){
            if(!isCharging){
                if(sfxMan){
                //sfxMan.playerCharge.Play();
                }
            }
            if(sfxMan){
            sfxMan.FlameBase.Play();
            }
            isCharging = true;
            if(isCharging == true){
                chargeTime += Time.deltaTime * chargeSpeed;
            }
        }
        if(Input.GetButtonUp("Fire1") && chargeTime < 2){
            if(sfxMan){
            sfxMan.FlameBase.Play();
            //sfxMan.playerCharge.Stop();
            }
            chargeTime = 0;
        }
        SetChargeAnimation(chargeTime);
        if(Input.GetButtonUp("Fire1") && chargeTime >= 2 ){
            if(sfxMan){
            sfxMan.FlameBase.Play();
            }
            releaseCharge(shotFired);
            charge1.SetActive(false);
            charge2.SetActive(false);
            charge3.SetActive(false);
        }
    }


    void SetChargeAnimation(float chargetime){
        //equipment will affect this. 
        
        if(chargetime >= 2){
            charge1.SetActive(true);
            shotFired = myInventory.currentWeapon.projectile1;
            pattern = 1;
        }
        if(chargetime >= 4 && uiMan.gunLevel == 2){
            charge1.SetActive(false);
            charge2.SetActive(true);
            shotFired = myInventory.currentWeapon.projectile2;
            pattern = 2;
        }
        if(chargetime >=6 && uiMan.gunLevel == 3){
            charge2.SetActive(false);
            charge3.SetActive(true);
            shotFired = myInventory.currentWeapon.projectile3;
            pattern = 3;
        }
    }

    

    //FIXME write function, determine charge level

    void releaseCharge(GameObject chargedShot){
        float x = animator.GetFloat("LastMoveX");
        float y = animator.GetFloat("LastMoveY");
        //firepattern 1 with projectile 1, one shot in facing direction
        if(pattern == 1){
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

        if(pattern == 2){
        if(x == 0 && y > 0){
            var shot1 = Instantiate(chargedShot, fire90.position, fire90.rotation);
            var shot2 = Instantiate(chargedShot, fire120.position, fire120.rotation);
            var shot3 = Instantiate(chargedShot, fire60.position, fire60.rotation);
            Destroy(shot1, 5f);
            Destroy(shot2, 5f);
            Destroy(shot3, 5f);
        }
        if(x == 0 && y < 0){
            var shot1 = Instantiate(chargedShot, fire270.position, fire270.rotation);
            var shot2 = Instantiate(chargedShot, fire210.position, fire210.rotation);
            var shot3 = Instantiate(chargedShot, fire300.position, fire300.rotation);
            Destroy(shot1, 5f);
            Destroy(shot2, 5f);
            Destroy(shot3, 5f);
        }
        if(x > 0 && y == 0){
            var shot1 = Instantiate(chargedShot, fire0.position, fire0.rotation);
            var shot2 = Instantiate(chargedShot, fire30.position, fire30.rotation);
            var shot3 = Instantiate(chargedShot, fire330.position, fire330.rotation);
            Destroy(shot1, 5f);
            Destroy(shot2, 5f);
            Destroy(shot3, 5f);
        }
        if(x < 0 && y == 0){
            var shot1 = Instantiate(chargedShot, fire180.position, fire180.rotation);
            var shot2 = Instantiate(chargedShot, fire210.position, fire210.rotation);
            var shot3 = Instantiate(chargedShot, fire150.position, fire150.rotation);
            Destroy(shot1, 5f);
            Destroy(shot2, 5f);
            Destroy(shot3, 5f);
        }
        isCharging = false;
        chargeTime = 0;
        }

        if(pattern == 3){
            var shot1 = Instantiate(chargedShot, fire0.position, fire0.rotation);
            var shot2 = Instantiate(chargedShot, fire30.position, fire30.rotation);
            var shot3 = Instantiate(chargedShot, fire60.position, fire60.rotation);
            var shot4 = Instantiate(chargedShot, fire90.position, fire90.rotation);
            var shot5 = Instantiate(chargedShot, fire120.position, fire120.rotation);
            var shot6 = Instantiate(chargedShot, fire150.position, fire150.rotation);
            var shot7 = Instantiate(chargedShot, fire180.position, fire180.rotation);
            var shot8 = Instantiate(chargedShot, fire210.position, fire210.rotation);
            var shot9 = Instantiate(chargedShot, fire240.position, fire240.rotation);
            var shot10 = Instantiate(chargedShot, fire270.position, fire270.rotation);
            var shot11 = Instantiate(chargedShot, fire300.position, fire300.rotation);
            var shot12 = Instantiate(chargedShot, fire330.position, fire330.rotation);
            Destroy(shot1, 5f);
            Destroy(shot2, 5f);
            Destroy(shot3, 5f);
            Destroy(shot4, 5f);
            Destroy(shot5, 5f);
            Destroy(shot6, 5f);
            Destroy(shot7, 5f);
            Destroy(shot8, 5f);
            Destroy(shot9, 5f);
            Destroy(shot10, 5f);
            Destroy(shot11, 5f);
            Destroy(shot12, 5f);
            isCharging = false;
            chargeTime = 0;
        }



        //firepattern 2 projectile 2, 3 shots in 60 degree spread

        //firepattern 3 projectile 3, 360 degree spread. 
    }

    

}
