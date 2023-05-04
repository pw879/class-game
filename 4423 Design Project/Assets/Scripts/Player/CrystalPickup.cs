using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public int value;
    public MoneyManager theMM;
    private SFXManager sfxMan;

    // Start is called before the first frame update
    void Start()
    {
        theMM = FindObjectOfType<MoneyManager>();
        sfxMan = FindObjectOfType<SFXManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other ){
        if(other.gameObject.tag == "MyPlayer"){
            sfxMan.pickUpCrystal.Play();
            theMM.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
