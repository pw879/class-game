using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDoorSetActive : MonoBehaviour
{
    private Animator animator;
    private Collider2D collider; 

    private void Awake(){
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    public void openDoor(){
        animator.SetBool("Open", true);
        //collider.enabled = false;
    }

    public void closeDoor(){
        animator.SetBool("Open", false);
        //collider.enabled = true;
    }
}

