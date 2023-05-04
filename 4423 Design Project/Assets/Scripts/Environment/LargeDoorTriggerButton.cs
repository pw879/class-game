using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDoorTriggerButton : MonoBehaviour
{
    [SerializeField] private DoorSetActive door;
    [SerializeField] private LargeDoorFloorTrigger floorTrigger;
    private SFXManager sfxMan;

    private Transform playerTransform;
    public float interactRadius;
    private bool isOpen = false;
    public bool canOpen = true;

    void Start(){
        playerTransform = GameObject.FindWithTag("MyPlayer").transform;
        sfxMan = FindObjectOfType<SFXManager>();
    }
    

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.F)  && isOpen == false && floorTrigger.isActive == true && canOpen == true){
            door.openDoor();
            isOpen = true;
        } else if (Input.GetKeyDown(KeyCode.F) && isOpen == true && floorTrigger.isActive == true && canOpen == true){
            door.closeDoor();
            isOpen = false;
        } else if(Input.GetKeyDown(KeyCode.F) && isOpen == false && floorTrigger.isActive == true && canOpen == false){
            if(sfxMan){
            sfxMan.DoorFail.Play();
            }
        }
    }
} 
    

