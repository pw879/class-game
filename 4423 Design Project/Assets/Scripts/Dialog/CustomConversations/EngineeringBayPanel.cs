using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineeringBayPanel: MonoBehaviour
{
    
    public string[] lines;
    public string[] lines2;
    public PlayerInventory inventory;
    public InventoryItem VoidWeapons;
    public LargeDoorTriggerButton blastDoor;
    private SFXManager sfxMan;
    
    void Start(){
        sfxMan = FindObjectOfType<SFXManager>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "MyPlayer"){
            DialogManager.instance.moveOverride = true;
            if(!DialogManager.instance.dialogBox.activeInHierarchy){
                if(sfxMan){
                sfxMan.DoorPanel.Play();
                }
                if(inventory.myInventory.Contains(VoidWeapons)){
                DialogManager.instance.showDialog(lines2);
                blastDoor.canOpen = true;
                } else{
                    DialogManager.instance.showDialog(lines);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "MyPlayer"){
            DialogManager.instance.moveOverride = false;
            DialogManager.instance.closeDialog();
        }
    }
}
