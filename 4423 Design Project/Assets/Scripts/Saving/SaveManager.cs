using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public PlayerInventory inventory;
    public MoneyManager moneyMan;
    public HealthManager healthMan;
    public VectorValue check;
    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(){
        List<string> allItems = new List<string>();
        allItems.Add("Arc Generator Acceleration Chamber");
        allItems.Add("Arc Generator Thano Capacitor");
        allItems.Add("Incenerator Acceleration Chamber");
        allItems.Add("Incinterator Thano Capacitor");
        allItems.Add("Microfusion Arc Thrower");
        allItems.Add("Microfusion Incenerator");
        allItems.Add("Void Generator Acceleration Chamber");
        allItems.Add("Void Generator Thano Capacitor");
        allItems.Add("Microfusion Void Emitter");
        allItems.Add("Nano Repair");
        allItems.Add("Droid MotherBoard");
        allItems.Add("LifeSupportRepairProgram");
        allItems.Add("Grade 2 Nano Coating");
        allItems.Add("Grade1 Nano Coating");
        allItems.Add("Void Included Nano Crystal Coating");

        List<string> listItems = new List<string>();

        if(PlayerPrefs.HasKey("item1")){
            listItems.Add(PlayerPrefs.GetString("item1"));
        }
        if(PlayerPrefs.HasKey("item2")){
            listItems.Add(PlayerPrefs.GetString("item2"));
        }
        if(PlayerPrefs.HasKey("item3")){
            listItems.Add(PlayerPrefs.GetString("item3"));
        }
        if(PlayerPrefs.HasKey("item4")){
            listItems.Add(PlayerPrefs.GetString("item4"));
        }
        if(PlayerPrefs.HasKey("item5")){
            listItems.Add(PlayerPrefs.GetString("item5"));
        }
        if(PlayerPrefs.HasKey("item6")){
            listItems.Add(PlayerPrefs.GetString("item6"));
        }
        if(PlayerPrefs.HasKey("item7")){
            listItems.Add(PlayerPrefs.GetString("item7"));
        }
        if(PlayerPrefs.HasKey("item8")){
            listItems.Add(PlayerPrefs.GetString("item8"));
        }
        if(PlayerPrefs.HasKey("item9")){
            listItems.Add(PlayerPrefs.GetString("item9"));
        }
        if(PlayerPrefs.HasKey("item10")){
            listItems.Add(PlayerPrefs.GetString("item10"));
        }
        if(PlayerPrefs.HasKey("item11")){
            listItems.Add(PlayerPrefs.GetString("item11"));
        }
        if(PlayerPrefs.HasKey("item12")){
            listItems.Add(PlayerPrefs.GetString("item12"));
        }
        if(PlayerPrefs.HasKey("item13")){
            listItems.Add(PlayerPrefs.GetString("item13"));
        }
        if(PlayerPrefs.HasKey("item14")){
            listItems.Add(PlayerPrefs.GetString("item14"));
        }
        if(PlayerPrefs.HasKey("item15")){
            listItems.Add(PlayerPrefs.GetString("item15"));
        }
        if(PlayerPrefs.HasKey("item16")){
            listItems.Add(PlayerPrefs.GetString("item16"));
        }
        if(PlayerPrefs.HasKey("item17")){
            listItems.Add(PlayerPrefs.GetString("item17"));
        }

        foreach(string name in listItems){
            foreach(InventoryItem item in inventory.allInventory){
                if(name == item.itemName){
                    if(!inventory.myInventory.Contains(item)){
                    inventory.myInventory.Add(item);
                    }
                }
            }
        }

        healthMan.currentHealth = PlayerPrefs.GetInt("CurrentHealth");

        moneyMan.currentCrystals = PlayerPrefs.GetInt("CurrentMoney");

        inventory.expVal = PlayerPrefs.GetInt("CurrentEXP");

        if(PlayerPrefs.GetString("Captain") == "yes"){
            check.speakToCaptain = true;
        } else {
            check.speakToCaptain = false;
        }

        if(PlayerPrefs.GetString("Droid") == "yes"){
            check.fixedDroid = true;
        } else {
            check.fixedDroid = false;
        }

        if(PlayerPrefs.GetString("fixedLS") == "yes"){
            check.fixedLifeSupport = true;
        } else {
            check.fixedLifeSupport = false;
        }
        
        

    }

    void SaveData(){

        List<string> ItemNames = new List<string>();
        foreach( InventoryItem item in inventory.myInventory){
            ItemNames.Add(item.itemName);
        }
        int count = 0;
        foreach(string name in ItemNames){
            count += 1;
            PlayerPrefs.SetString("item" + count, name);
        }

        PlayerPrefs.SetInt("CurrentMoney", moneyMan.currentCrystals );

        PlayerPrefs.SetInt("CurrentHealth", healthMan.currentHealth);

        PlayerPrefs.SetInt("CurrentEXP", inventory.expVal);

        if(check.speakToCaptain == true){
            PlayerPrefs.SetString("Captain", "yes");
        } else{
            PlayerPrefs.SetString("Captain", "no");
        }

        if(check.fixedDroid == true){
            PlayerPrefs.SetString("Droid", "yes");
        } else{
            PlayerPrefs.SetString("Droid", "no");
        }

        if(check.fixedLifeSupport == true){
            PlayerPrefs.SetString("fixedLS", "yes");
        } else{
            PlayerPrefs.SetString("fixedLS", "no");
        }















    }

    //Location

    //Gold

    //Inventory
    

    //EXP

    //ProgressChecks
}
