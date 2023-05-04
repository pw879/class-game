using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDoorTrigger : MonoBehaviour
{
    [SerializeField] private SmallDoorFloorTrigger floorTrigger;
    [SerializeField] private SmallDoorSetActive door;
    private Transform playerTransform;
    //public float interactRadius;
    private bool isOpen = false;
    public bool canOpen = true;
    private SFXManager sfxMan;

    void Start(){
        playerTransform = GameObject.FindWithTag("MyPlayer").transform;
        sfxMan = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update(){
            if(Input.GetKeyDown(KeyCode.F) && floorTrigger.isActive == true && isOpen == false && canOpen == true ){
                door.openDoor();
                isOpen = true;
            }
            else if(Input.GetKeyDown(KeyCode.F) && floorTrigger.isActive == true && isOpen == true && canOpen == true ) {
                door.closeDoor();
                isOpen = false;
            }
            else if(Input.GetKeyDown(KeyCode.F) && floorTrigger.isActive == true && isOpen == false && canOpen == false ){
                if(sfxMan){
                sfxMan.DoorFail.Play();
                }
            }
    }
}
