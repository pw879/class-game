using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //references to the item that this slot is representing
    [Header("UI things to change")]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private Image itemImage;

    [Header("Variables from the item")]
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    // the parameters are set by the inventory manager
    public void Setup(InventoryItem newItem, InventoryManager newManager){ 
        thisItem = newItem;
        thisManager = newManager;
        if(thisItem != null){
            itemImage.sprite = thisItem.itemImage;
            itemNumberText.text = "" + thisItem.numberHeld; 
        }
    }

    //called when the an item is tapped on
    public void ClickedOn(){
        if(thisItem){ // Item existence check
            thisManager.SetupDescriptionAndButton(thisItem.itemDescription, thisItem.usable, thisItem);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
