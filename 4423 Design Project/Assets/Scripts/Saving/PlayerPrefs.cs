using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData(){

        //PlayerPrefs.SetFloat();
        //PlayerPrefs.SetString();
        //PlayerPrefs.SetInt();

        //Example
        //PlayerPrefs.SetString("Key", "SomeText");
    }

    public void LoadData(){
        //PlayerPrefs.GetString("Key"); //pass in the key
    }

    public void DeleteData(){
        //PlayerPrefs.DeleteKey("Key");
        //PlayerPrefs.DeleteAll();
    }
}
