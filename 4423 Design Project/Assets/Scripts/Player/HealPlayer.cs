using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    private HealthManager healthMan;

    public void Heal(){
        healthMan = FindObjectOfType<HealthManager>(); 
        healthMan.currentHealth = healthMan.maxHealth;
    }
}
