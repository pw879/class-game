using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("MyPlayer")){
            ShopManager.instance.ToggleShop();
        }
    }

    private void OnTriggerExit2D(Collider2D other){
                if(other.CompareTag("MyPlayer")){
            ShopManager.instance.ToggleShop();
        }
    }
}