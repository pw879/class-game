using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("Player")]
    public AudioSource playerHurt;
    public AudioSource playerDead;
    public AudioSource playerAttack;
    public AudioSource pickUpCrystal;
    public AudioSource playerRun;
    public AudioSource playerCharge;
    public AudioSource playerChargeComplete;
    [Header("Enemy")]
    public AudioSource enemyHurt;
    public AudioSource enemyMiss;
    [Header("Environment")]
    public AudioSource DoorSmallOpen;
    public AudioSource DoorLargeOpen;
    public AudioSource DoorPanel;
    public AudioSource ChestOpen;
    public AudioSource DoorFail;
    [Header("Weapons")]
    public AudioSource ArcBase;
    public AudioSource Arc2;
    public AudioSource Arc3;
    public AudioSource FlameBase;
    public AudioSource Flame2;
    public AudioSource Flame3;
    public AudioSource VoidBase;
    public AudioSource Void2;
    public AudioSource Void3;


    private static bool SFXExists;

    // Start is called before the first frame update
    void Start()
    {
        if(!SFXExists){
            SFXExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else{
            Destroy(gameObject);
        }
    }
}
