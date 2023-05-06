using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private HealthManager healthMan;
    private PlayerStats thePS;
    public PlayerInventory inventory;
    private Gun myGun;
    public Slider healthBar;
    public Slider chargeBar;
    public Slider chargeLevel;
    public Text hpText;
    public int gunLevel;

    [Header("Weapon Classes")]
    public InventoryItem flame;
    public InventoryItem Arc;
    public InventoryItem Void;

    public InventoryItem flame2;
    public InventoryItem Arc2;
    public InventoryItem Void2;

    public InventoryItem flame3;
    public InventoryItem Arc3;
    public InventoryItem Void3;

    [Header("Leveling")]
    public Text EXPText;
    public Text LVLText;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
        thePS = GetComponent<PlayerStats>();
        myGun = FindObjectOfType<Gun>();
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        setGunLevel();
        // set the value displayed on the healthbar
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;
        setChargeBar();
        setHealthText();
        LVLText.text = thePS.currentLevel.ToString();
        if(!(thePS.currentLevel == 9)){
        EXPText.text = "EXP: " + thePS.currentExp.ToString() + "/ " + thePS.toLevelUp[thePS.currentLevel + 1].ToString(); 
        } else {
            EXPText.text = "EXP: " + thePS.currentExp.ToString() + "/ " + thePS.toLevelUp[thePS.currentLevel].ToString(); 
        }
    }

    void setGunLevel(){
        if(inventory.currentWeapon == flame){
            if(inventory.myInventory.Contains (flame2)){
                gunLevel = 2;
            }
            if(inventory.myInventory.Contains(flame2) && inventory.myInventory.Contains(flame3)){
                gunLevel = 3;
            }
        }
        if(inventory.currentWeapon == Arc){
            if(inventory.myInventory.Contains(Arc2)){
                gunLevel = 2;
            }
            if(inventory.myInventory.Contains(Arc2) && inventory.myInventory.Contains(Arc3)){
                gunLevel = 3;
            }
        }
        if(inventory.currentWeapon == Void){
            if(inventory.myInventory.Contains(Void2)){
                gunLevel = 2;
            }
            if(inventory.myInventory.Contains(Void2) && inventory.myInventory.Contains(Void3)){
                gunLevel = 3;
            }
        }
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
        if(myGun.chargeTime >= 4 && myGun.chargeTime <= 6 && gunLevel == 2){
            chargeBar.maxValue = 2;
            chargeBar.value = (myGun.chargeTime - 4);
            chargeLevel.maxValue = 3;
            chargeLevel.value = 2;
        }
        // check if the chargeTime is more than 6 seconds (level 3)
        if(myGun.chargeTime >= 6 && gunLevel ==3){
            chargeBar.maxValue = 2;
            chargeBar.value = (myGun.chargeTime - 6);
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
