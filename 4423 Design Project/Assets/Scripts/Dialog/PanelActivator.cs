using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    
    public string[] lines;
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
                DialogManager.instance.showDialog(lines);
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
