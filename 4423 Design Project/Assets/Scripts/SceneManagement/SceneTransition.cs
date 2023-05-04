using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    private HealthManager healthMan;


    private void OnTriggerEnter2D(Collider2D other){
        healthMan = FindObjectOfType<HealthManager>();
        if(other.CompareTag("MyPlayer") && !other.isTrigger){
            playerStorage.initialValue = playerPosition;
            playerStorage.currentHealth = healthMan.currentHealth;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
