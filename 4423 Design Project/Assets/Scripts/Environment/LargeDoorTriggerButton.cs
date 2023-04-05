using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDoorTriggerButton : MonoBehaviour
{
    [SerializeField] private DoorSetActive door;
    [SerializeField] private Transform playerTransform;
    public float interactRadius;
    private bool isOpen = false;

    // Update is called once per frame
    void Update(){
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(playerTransform.position, interactRadius );
        foreach (Collider2D col in colliderArray){
            DoorSetActive door = col.GetComponent<DoorSetActive>();
            if(door != null){
            if(Input.GetKeyDown(KeyCode.F) && isOpen == false){
                door.openDoor();
                isOpen = true;
            } else if (Input.GetKeyDown(KeyCode.F) && isOpen == true){
                door.closeDoor();
                isOpen = false;
            }
            }
        } 
    }
}
