using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTriggerButton : MonoBehaviour
{
    [SerializeField] private ChestAnimated chest;
    [SerializeField] private ChestFloorTrigger floorTrigger;
    private Transform playerTransform;

    public string[] ItemMessage;
    public string[] EmptyMessage;

    public float interactRadius;
    private bool isOpen = false;
    public bool isEmpty = false;
    private bool isActive = false;
    private SFXManager sfxMan;

    public InventoryItem item;
    public PlayerInventory inventory;
    //containing scriptable object item. 

    void Start(){
        playerTransform = GameObject.FindWithTag("MyPlayer").transform;
        sfxMan = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update(){

            if(Input.GetKeyDown(KeyCode.F) && floorTrigger.isActive == true && isOpen == false ){
                Debug.Log("Open Chest");
                if(sfxMan){
                sfxMan.ChestOpen.Play();
                }
                chest.openChest();
                if(!DialogManager.instance.dialogBox.activeInHierarchy){
                    if(isEmpty == false){
                        DialogManager.instance.showDialog(ItemMessage);
                        //transfer item to inventory
                        takeItem();
                        isEmpty = true;
                    } else{
                        DialogManager.instance.showDialog(EmptyMessage);
                    }
                isOpen = true;
                }

            } else if(Input.GetKeyDown(KeyCode.F) && floorTrigger.isActive == true && isOpen == true ){
                if(sfxMan){
                sfxMan.ChestOpen.Play();
                }
                chest.closeChest();
                isOpen = false;
            }
    }

    void takeItem(){
        // make sure not null
        if(inventory && item){
            if(inventory.myInventory.Contains(item)){
                item.numberHeld += 1;
            } else {
                inventory.myInventory.Add(item);
                item.numberHeld += 1;
            }
        }
    }

            //} else if (Input.GetKeyDown(KeyCode.F) && isOpen == true){
            //    chest.closeChest();
            //    isOpen = false;
            //}
    
    
}




// chest is closed
// player enters chests radius and hits f
// box opens and the trigger area appears
// if player is witin the trigger area the item is transferred and a message appears, 
// the box is marked empty. 
// 

                //if(!DialogManager.instance.dialogBox.activeInHierarchy){
                //    DialogManager.instance.showDialog(ItemMessage);
                    //transfer item to inventory
                //    }
                
                //if(isEmpty == true){
                //    if(!DialogManager.instance.dialogBox.activeInHierarchy){
                //    DialogManager.instance.showDialog(EmptyMessage);
                    
                //}
