using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    [Header("BaseAttack Fire Modes")]
    [SerializeField] private GameObject FireBaseShot;
    [SerializeField] private GameObject ElecticityBaseShot;
    [SerializeField] private GameObject DarkBaseShot;

    [Header("Charged Shots Fire")]
    [SerializeField] private GameObject FireChargedShot1;
    [SerializeField] private GameObject FireChargedShot2;
    [SerializeField] private GameObject FireChargedShot3;
    
    [Header("Charged Shots Electricity")]
    [SerializeField] private GameObject ElectricChargedShot1;
    [SerializeField] private GameObject ElectricChargedShot2;
    [SerializeField] private GameObject ElectricChargedShot3;

    [Header("Charged Shots Dark")]
    [SerializeField] private GameObject DarkChargedShot1;
    [SerializeField] private GameObject DarkChargedShot2;
    [SerializeField] private GameObject DarkChargedShot3;    
}


