using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public string bossName; 
    public int bossHealth;

    public GameObject theBoss;
    public BossGun gun;
    public Transform[] spawnPoints;
    private Vector3 moveTarget;
    public float moveSpeed;
    public float timeActive;
    public float timeBetweenSpawns;
    public float firstSpawnDelay;
    public float activeCounter;
    public float spawnCounter;
    public LargeDoorTriggerButton exit;
    public SmallDoorTrigger entry;
    public float shotCounter;
    public float timeBetweenShots = 1.5f;


    

    // Start is called before the first frame update
    void Start()
    {
        // happens as soon as activated
        spawnCounter = firstSpawnDelay;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHealth > 0 && gameObject.activeSelf){
        if(spawnCounter > 0 && gameObject.activeSelf){
            spawnCounter -= Time.deltaTime;
            if(spawnCounter < 0){
                activeCounter = timeActive;
                theBoss.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                moveTarget = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                while(moveTarget == theBoss.transform.position){
                    moveTarget = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                }
                theBoss.SetActive(true);
            }
        }
        else 
        {
            if(gameObject.activeSelf){
            activeCounter -= Time.deltaTime;
            if(activeCounter <= 0){
                spawnCounter = timeBetweenSpawns;
                theBoss.SetActive(false);
            }
            theBoss.transform.position = Vector3.MoveTowards(theBoss.transform.position, moveTarget, moveSpeed * Time.deltaTime);
            shotCounter -= Time.deltaTime;
            if(shotCounter < 0){
                shotCounter = timeBetweenShots;
                gun.SpawnProjectiles();

            }

            }
        }
        }else{
            exit.canOpen = true;
            entry.canOpen = true;
        }
    }
 

     public void TakeDamage(int damageToTake){
        bossHealth -= damageToTake;
        if(bossHealth <= 0){
            bossHealth = 0;
            theBoss.SetActive(false);
        }
    }
}


