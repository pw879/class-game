using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;
    [SerializeField] private Transform playerTransform;
    public float interactRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(playerTransform.position, interactRadius );
        foreach (Collider2D col in colliderArray){
            PhysicalInventoryItem item = col.GetComponent<PhysicalInventoryItem>();
            if(item != null){
                if(Input.GetKeyDown(KeyCode.F)){
                addItemToInventory();
                Destroy(this.gameObject);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("MyPlayer")){
            if(thisItem.autoPickup){
            addItemToInventory();
            Destroy(this.gameObject);
            }
        }
    }

    void addItemToInventory(){
        // make sure not null
        if(playerInventory && thisItem){
            if(playerInventory.myInventory.Contains(thisItem)){
                thisItem.numberHeld += 1;
            } else {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }

        }
    }
}
