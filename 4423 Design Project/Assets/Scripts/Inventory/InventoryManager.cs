using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory PlayerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;

    public void SetTextAndButton(string description, bool buttonActive){
        descriptionText.text = description;
        if(buttonActive){
            useButton.SetActive(true);
        }else{
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlots(){
        if(PlayerInventory){ // to check for null reference exception
        //go over every item in the inventory and set up a slot for each inventory item
            for(int i = 0; i < PlayerInventory.myInventory.Count; i++){
                //check for zero quantity
                if(PlayerInventory.myInventory[i].numberHeld >0){
                GameObject temp = 
                    Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);
                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if(newSlot){
                    
                    newSlot.Setup(PlayerInventory.myInventory[i], this);
                    }
                }
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem){
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable); 

    }

    public void useButtonPressed(){
        if(currentItem){
            currentItem.Use();
            //Clear all inventory slots
            //refill them all to reflect new numbers
            clearInventorySlots();
            MakeInventorySlots();
            //check for 0
            if(currentItem.numberHeld == 0 ){
                SetTextAndButton("", false );
            }
        }
    }

    void clearInventorySlots(){
        for(int i = 0; i < inventoryPanel.transform.childCount; i++){
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }




}
