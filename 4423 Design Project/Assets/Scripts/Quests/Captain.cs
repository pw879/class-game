using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captain : MonoBehaviour
{
    public VectorValue check;
    private bool isActive;

    void Update(){
        if(Input.GetKeyDown(KeyCode.F)  && isActive == true){
            speakToCaptain();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
            if(other.tag == "MyPlayer"){
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "MyPlayer"){
            isActive = false;
        }
    }
    
    public void speakToCaptain(){
        check.speakToCaptain = true;
    }
}
