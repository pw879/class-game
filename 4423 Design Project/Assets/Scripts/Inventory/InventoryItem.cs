using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory / Items")]
public class InventoryItem : ScriptableObject
{
    [Header("GENERAL Properties")]
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool canEquip;
    public bool unique;
    public bool autoPickup;

    [Header("ARMOR Properties")]
    public bool isArmor;
    public int armorVal;

    [Header("WEAPON Properties")]
    public bool isWeapon;
    public int attackVal;
    public GameObject baseFire;
    public GameObject projectile1; //firing script built into prefab. 
    public GameObject projectile2; //firing script built into prefab. 
    public GameObject projectile3; //firing script built into prefab

    [Header("WeaponClass, 0 = none, 1 = fire, 2 = electric, 3 = void")]
    public int weaponClass;

    [Header("Equip Status")]
    public bool isEquiped;

    public UnityEvent thisEvent; // new event


    public void Use(){

        // call whatever methods are being used by this event
        thisEvent.Invoke(); 
    }


    public void DecreaseAmount(int amountToDecrease){
        numberHeld -= amountToDecrease;
        if(numberHeld < 0){
            numberHeld = 0;
        }
    }


}
