using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    
    public string[] lines;
    private bool canActivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // make sure dialog is not currently active
        if(canActivate && Input.GetKeyUp(KeyCode.F) && !DialogManager.instance.dialogBox.activeInHierarchy ){ // make sure dialog is not currently active
            DialogManager.instance.showDialog(lines);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "MyPlayer"){
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "MyPlayer"){
            canActivate = false;
        }
    }
}
