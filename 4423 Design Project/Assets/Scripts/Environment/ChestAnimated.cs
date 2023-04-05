using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimated : MonoBehaviour
{
    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    public void openChest(){
        animator.SetBool("Open", true);
    }

    public void closeChest(){
        animator.SetBool("Open", false);
    }

}
