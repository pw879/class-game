using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupportPanel: MonoBehaviour
{
    
    public string[] lines;
    public string[] lines2;
    public PlayerInventory inventory;
    public InventoryItem lifeSupportFix;
    public VectorValue check;
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
                if(inventory.myInventory.Contains(lifeSupportFix)){
                DialogManager.instance.showDialog(lines2);
                check.fixedLifeSupport = true;
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
