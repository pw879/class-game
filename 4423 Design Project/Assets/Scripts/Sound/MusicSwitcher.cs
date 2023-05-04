using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    //uses trigger box or scenes
    private MusicManager theMM;
    public int newTrack;
    public bool switchOnStart;

    // Start is called before the first frame update
    void Start()
    {
        theMM = FindObjectOfType<MusicManager>();
        if(theMM && switchOnStart){
            theMM.SwitchTrack(newTrack);
            //gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "MyPlayer"){
            if(theMM){
            theMM.SwitchTrack(newTrack);
            gameObject.SetActive(false); //deactivates the whole trigger box.
            }
        }
    }
}
