using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public int coins = 300;
    public Upgrade[] upgrades;

    // References
    //public Text coinText;
    public TextMeshProUGUI coinText;
    public GameObject shopUI;
    public Transform shopContent;
    public GameObject itemPrefab;
    public PlayerInventory inventory;

    private void Awake(){
        if(instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Start(){
        foreach(Upgrade upgrade in upgrades){
            GameObject item = Instantiate(itemPrefab, shopContent);
            upgrade.itemRef = item;
            foreach(Transform child in item.transform){ //quantity, image, name cost these are the parts
                if(child.gameObject.name == "Quantity"){
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = upgrade.quantity.ToString();
                } else if((child.gameObject.name == "Cost")){
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = "$ " + upgrade.cost.ToString();
                } else if((child.gameObject.name == "Name")){
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = upgrade.name;
                } else if((child.gameObject.name == "Image")){
                    child.gameObject.GetComponent<Image>().sprite = upgrade.image;
                }

            }
            item.GetComponent<Button>().onClick.AddListener(() => { 
            BuyUpgrade(upgrade);
            });
        }


    }

    public void BuyUpgrade(Upgrade upgrade){
        if(coins >= upgrade.cost){
            coins -= upgrade.cost;
            upgrade.quantity++; // probably not applicable
            upgrade.itemRef.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = upgrade.quantity.ToString();
            storeItem(upgrade);

        }
    }

        void storeItem(Upgrade upgrade){
        // make sure not null
        if(inventory && upgrade.item){
            if(inventory.myInventory.Contains(upgrade.item)){
                upgrade.item.numberHeld += 1;
            } else {
                inventory.myInventory.Add(upgrade.item);
                upgrade.item.numberHeld += 1;
            }

        }
    }


    public void ToggleShop(){
        shopUI.SetActive(!shopUI.activeSelf);
    }

    private void OnGUI(){
        coinText.text = "Credits: " + coins.ToString();
    }

}

[System.Serializable]
public class Upgrade{
    public string name;
    public int cost;
    public Sprite image;
    public InventoryItem item;
    [HideInInspector] public int quantity; // how many you already own
    [HideInInspector] public GameObject itemRef;

}
