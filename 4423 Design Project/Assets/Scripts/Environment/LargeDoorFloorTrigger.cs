using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDoorFloorTrigger : MonoBehaviour
{
    public bool isActive;

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
}
