using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("MyPlayer")){
            addItemToInventory();
            Destroy(this.gameObject);
        }
    }

    void addItemToInventory(){
        // make sure not null
        if(playerInventory && thisItem){
            if(playerInventory.myInventory.Contains(thisItem)){
                thisItem.numberHeld += 1;
            } else {
                playerInventory.myInventory.Add(thisItem);
            }

        }
    }
}
