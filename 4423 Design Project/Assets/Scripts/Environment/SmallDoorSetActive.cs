using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDoorSetActive : MonoBehaviour
{
    private Animator animator;
    private Collider2D collider; 
    private SFXManager sfxMan;

    void Start(){
        if(sfxMan){
        sfxMan = FindObjectOfType<SFXManager>();
        }
    }

    private void Awake(){
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    public void openDoor(){
        if(sfxMan){
        sfxMan.DoorSmallOpen.Play();
        }
        animator.SetBool("Open", true);
        collider.enabled = false;
    }

    public void closeDoor(){
        if(sfxMan){
        sfxMan.DoorSmallOpen.Play();
        }
        animator.SetBool("Open", false);
        collider.enabled = true;
    }
}

