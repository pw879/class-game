using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    private int currentHealth;
    public GameObject deathPreFab;
    public Transform trianglePosition;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        Debug.Log(currentHealth);
        DetectDeath();

    }

    private void DetectDeath(){
        if(currentHealth <= 0){
            gameObject.SetActive(false);
            GameObject death = Instantiate(deathPreFab, trianglePosition.position, trianglePosition.rotation);
            Destroy(death, .68f);
        }
    }
}
