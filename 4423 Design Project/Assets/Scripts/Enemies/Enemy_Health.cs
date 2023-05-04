using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 25;
    [SerializeField] private GameObject floatingTextPrefab;

    [Header("Player Stats")]
    private PlayerStats myPlayerStats;
    [Header("EXP")]
    public int expToGive;

    private int currentHealth;
    public GameObject deathPreFab;
    public GameObject crystalDrop;
    private GameObject cr;
    public int crystalMaxValue;
    public int healthDropChance;
    public Transform trianglePosition;
    private Transform loc;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        myPlayerStats = FindObjectOfType<PlayerStats>();
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        Debug.Log(currentHealth);
        ShowDamage(damage.ToString());
        DetectDeath();

    }

    private void DetectDeath(){
        if(currentHealth <= 0){
            Vector3 loc = gameObject.transform.position;
            GameObject death = Instantiate(deathPreFab, loc, Quaternion.identity);
            Destroy(death, .68f);
            //add experience
            myPlayerStats.AddExperience(expToGive);
            if(Random.Range(0f, 100f) < healthDropChance){
                Debug.Log("ENEMY LOCATION + " + loc);
                GameObject cr = Instantiate(crystalDrop, loc, Quaternion.identity);
                cr.GetComponent<CrystalPickup>().value = Random.Range(1, crystalMaxValue + 1);
                
            }
            if(gameObject.GetComponent<BossController>() == null){
            Destroy(gameObject);
            }
        }
    }

    void ShowDamage(string text){
        Debug.Log("Showing Damage ...");
        //if(floatingTextPrefab){
            Debug.Log("There is a prefab found");
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        //}
    }
}
