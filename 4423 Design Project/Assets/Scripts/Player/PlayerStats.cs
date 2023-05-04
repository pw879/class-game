using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;
    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefence;

    [Header("Scripatble Objects")]
    public PlayerInventory myInventory;

    private HealthManager healthMan;

    // Start is called before the first frame update
    void Start()
    {
        currentExp = myInventory.expVal;
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];
        healthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentExp >= toLevelUp[currentLevel]){
            //currentLevel++;
            LevelUp();
        }
        
    }

    public void LevelUp(){
        currentLevel++;
        currentHP = HPLevels[currentLevel];
        healthMan.maxHealth = currentHP;
        healthMan.currentHealth = healthMan.maxHealth;
        
        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }

    public void AddExperience(int experienceToAdd){
        currentExp += experienceToAdd;
        myInventory.expVal = currentExp;
    }
}
