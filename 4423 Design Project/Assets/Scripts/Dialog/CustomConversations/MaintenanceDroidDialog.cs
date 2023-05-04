using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintenanceDroidDialog : MonoBehaviour
{
    
    public string[] lines;
    public string[] lines2;
    private bool canActivate;
    public LargeDoorTriggerButton blastDoor;
    public VectorValue tracker;
    public NPCmovement move;
    private SFXManager sfxMan;
    private int fcount = 0;

    
    void Start(){
        sfxMan = FindObjectOfType<SFXManager>();
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.G)){
            DialogManager.instance.closeDialog();
        }
        if(Input.GetKeyUp(KeyCode.F)){
                fcount += 1;
            }
        // make sure dialog is not currently active
        if(canActivate && Input.GetKeyUp(KeyCode.F) && !DialogManager.instance.dialogBox.activeInHierarchy ){ // make sure dialog is not currently active
            sfxMan.DoorPanel.Play();
            if(tracker.fixedLifeSupport == false){
                DialogManager.instance.showDialog(lines);
            }
            if(tracker.fixedLifeSupport == true){
                DialogManager.instance.showDialog(lines2);
                blastDoor.canOpen = true;
            }
            if(Input.GetKeyUp(KeyCode.F)){
                fcount += 1;
            }
            if(fcount >= 7){
            DialogManager.instance.closeDialog();
            fcount = 0;
            }
            //move.SetFloat("moveSpeed") = 0f;
        } 
        if(gameObject.GetComponent<NPCmovement>() != null){
            gameObject.GetComponent<NPCmovement>().canMove = false;
        }

        if(fcount >= 5){
            DialogManager.instance.closeDialog();
            fcount = 0;
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
