using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScienceOfficerDialog : MonoBehaviour
{
    public string[] lines;
    public string[] lines2;
    public string[] lines3;
    public VectorValue progress;
    private bool canActivate;
    public NPCmovement move;
    private SFXManager sfxMan;
    private int fcount = 0;
    public LargeDoorTriggerButton blastDoor;

    
    void Start(){
        sfxMan = FindObjectOfType<SFXManager>();
    }



    // Update is called once per frame
    void Update()
    {
        if(canActivate && Input.GetKeyUp(KeyCode.G)){
            DialogManager.instance.closeDialog();
        }
        
        if(Input.GetKeyDown(KeyCode.F)){
            fcount += 1;
        }
        if(fcount > 4){
            DialogManager.instance.closeDialog();
            fcount = 0;
        }
        if(progress.speakToCaptain == false){
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

        if(progress.speakToCaptain == true){
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
