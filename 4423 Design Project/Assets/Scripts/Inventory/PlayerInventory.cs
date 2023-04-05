using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory / PlayerInventory")]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();
    // a list of inventory objects, also a scriptable object so that we can have an instance of it
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
