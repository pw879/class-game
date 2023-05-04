using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //have to be public so that the button can read them
    public void NewGame(){
        SceneManager.LoadScene("Town 1");

    }

    public void QuitToDesktop(){
        Application.Quit();

    }


}
