using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public TMP_Text dialogText;
    public static DialogManager instance;

    public string[] dialogLines;
    public int currentLine;
    private bool justStarted;
    // Start is called before the first frame update

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogBox.activeInHierarchy){
            if(Input.GetKeyUp(KeyCode.F)){ // F{
                    if(!justStarted){
                    currentLine += 1;
                    if(currentLine >= dialogLines.Length){
                        dialogBox.SetActive(false);
                    } else{
                        dialogText.text = dialogLines[currentLine];
                    }
                    } else{
                        justStarted = false;
                    }
            }
        }
    }

    public void showDialog(string[] newLines){
        dialogLines = newLines;
        currentLine = 0;
        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
        justStarted = true;
    }
}
