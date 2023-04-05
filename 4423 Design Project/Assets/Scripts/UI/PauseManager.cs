using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public string mainMenu;
    public bool usingPausePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;   
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
        usingPausePanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            ChangePause();
        }
        
    }

    public void ChangePause(){
        isPaused = !isPaused; //toggles a boolean
        if(isPaused){
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            usingPausePanel = true;
        } else{
            inventoryPanel.SetActive(false);
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitToMain(){
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }

    public void SwitchPanels(){
        usingPausePanel = !usingPausePanel;
        if(usingPausePanel){
            pausePanel.SetActive(true);
            inventoryPanel.SetActive(false);
        } else {
            inventoryPanel.SetActive(true);
            pausePanel.SetActive(false);
        }

    }
}
