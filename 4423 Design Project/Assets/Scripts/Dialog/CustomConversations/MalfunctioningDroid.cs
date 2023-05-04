using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalfunctioningDroid : MonoBehaviour
{
    
    public string[] lines;
    public string[] lines2;
    private bool canActivate;
    public NPCmovement move;
    private SFXManager sfxMan;
    public PlayerInventory inventory;
    public InventoryItem motherboard;
    public LargeDoorTriggerButton blastDoor;
    private int fcount = 0;

    
    void Start(){
        sfxMan = FindObjectOfType<SFXManager>();
    }



    // Update is called once per frame
    void Update()
    {
        if(canActivate && Input.GetKeyUp(KeyCode.G)){
            DialogManager.instance.closeDialog();
        }
        // make sure dialog is not currently active
        if(inventory.myInventory.Contains(motherboard)){
            if(canActivate && Input.GetKeyUp(KeyCode.F) && !DialogManager.instance.dialogBox.activeInHierarchy ){ // make sure dialog is not currently active
                if(sfxMan){
                sfxMan.DoorPanel.Play();
                }
                DialogManager.instance.showDialog(lines2);
                blastDoor.canOpen = true;
                //move.SetFloat("moveSpeed") = 0f;
            } 
            if(gameObject.GetComponent<NPCmovement>() != null){
                gameObject.GetComponent<NPCmovement>().canMove = false;
            }       
        }
        if(!(inventory.myInventory.Contains(motherboard))){
            if(canActivate && Input.GetKeyUp(KeyCode.F) && !DialogManager.instance.dialogBox.activeInHierarchy ){ // make sure dialog is not currently active
                if(sfxMan){
                sfxMan.DoorPanel.Play();
                }
                DialogManager.instance.showDialog(lines);
                //move.SetFloat("moveSpeed") = 0f;
            } 
            if(gameObject.GetComponent<NPCmovement>() != null){
                gameObject.GetComponent<NPCmovement>().canMove = false;
            }       
        }
        

    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "MyPlayer"){
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "MyPlayer"){
            canActivate = false;
            
        }
    }
}
