using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTriggerButton : MonoBehaviour
{
    [SerializeField] private ChestAnimated chest;
    [SerializeField] private Transform playerTransform;
    public float interactRadius;
    private bool isOpen = false;

    // Update is called once per frame
    void Update(){
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(playerTransform.position, interactRadius );
        foreach (Collider2D col in colliderArray){
            ChestAnimated chest = col.GetComponent<ChestAnimated>();
            if(chest != null){
            if(Input.GetKeyDown(KeyCode.F) && isOpen == false){
                chest.openChest();
                isOpen = true;
            } else if (Input.GetKeyDown(KeyCode.F) && isOpen == true){
                chest.closeChest();
                isOpen = false;
            }
            }
        } 
    }
}
