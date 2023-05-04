using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPassover : MonoBehaviour
{
    
    public string[] lines;
    private bool canActivate;
    public NPCmovement move;


    // Update is called once per frame
    void Update()
    {
        // make sure dialog is not currently active
        if(canActivate && !DialogManager.instance.dialogBox.activeInHierarchy){ // make sure dialog is not currently active
            DialogManager.instance.showDialog(lines);     
    }
    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.tag == "MyPlayer"){
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "MyPlayer"){
            canActivate = false;
            DialogManager.instance.closeDialog();
            
        }
    }
}
