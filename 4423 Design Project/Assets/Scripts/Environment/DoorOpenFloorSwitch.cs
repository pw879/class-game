using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFloorSwitch : MonoBehaviour
{
    public VectorValue check;
    public LargeDoorTriggerButton blastDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "MyPlayer"){
            if(check.fixedLifeSupport == true){
                blastDoor.canOpen = true;
            }
        }
    }
}
