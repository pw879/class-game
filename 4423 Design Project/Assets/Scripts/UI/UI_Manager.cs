using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private HealthManager healthMan;
    private Gun myGun;
    public Slider healthBar;
    public Slider chargeBar;
    public Slider chargeLevel;
    public Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
        myGun = FindObjectOfType<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        // set the value displayed on the healthbar
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;
        setChargeBar();
        setHealthText();
    }

    void setChargeBar(){
    // check if the chargeTime is less than 2 seconds (level 0)
        if(myGun.chargeTime <= 2){
        chargeBar.maxValue = 2;
        chargeBar.value = myGun.chargeTime;
        chargeLevel.maxValue = 3;
        chargeLevel.value = 0;
        }
        // check if the chargeTime is more than 2 seconds and less than 4 (level 1)
        if(myGun.chargeTime >= 2 && myGun.chargeTime <= 4){
            chargeBar.maxValue = 2;
            chargeBar.value = (myGun.chargeTime - 2);
            chargeLevel.maxValue = 3;
            chargeLevel.value = 1;
        }
        // check if the chargeTime is more than 4 seconds and less than 6 (level 2)
        if(myGun.chargeTime >= 4 && myGun.chargeTime <= 6){
            chargeBar.maxValue = 2;
            chargeBar.value = (myGun.chargeTime - 4);
            chargeLevel.maxValue = 3;
            chargeLevel.value = 2;
        }
        // check if the chargeTime is more than 6 seconds (level 3)
        if(myGun.chargeTime >= 6){
            chargeBar.maxValue = 2;
            chargeBar.value = (myGun.chargeTime - 4);
            chargeLevel.maxValue = 3;
            chargeLevel.value = 3;
        }
    }

    void setHealthText(){
        // set text values for HP Label
        hpText.text = "HP: " + healthMan.currentHealth + "/" + healthMan.maxHealth; 
    }

    //TODO
    // set MP value
    // set level value
    // set exp value
}
