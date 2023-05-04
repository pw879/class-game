using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    //reference to text
    public Text moneyText;
    public int currentCrystals;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("CurrentMoney")){
        currentCrystals = PlayerPrefs.GetInt("CurrentMoney");
        } else {
            currentCrystals = 0;
            PlayerPrefs.SetInt("CurrentMoney", 0);
        }

        moneyText.text = "Crystals: " + currentCrystals;
    }

    public void AddMoney(int crystalsToAdd){
        currentCrystals += crystalsToAdd;
        PlayerPrefs.SetInt("CurrentMoney", currentCrystals );
        moneyText.text = "Crystals: " + currentCrystals;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
