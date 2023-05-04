using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string LevelToLoad;
    void OnTriggerEnter2D( Collider2D other){
        if(other.CompareTag("MyPlayer")){
            SceneManager.LoadScene(LevelToLoad);
        }

    }

}
