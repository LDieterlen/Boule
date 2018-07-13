using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightAnimator : MonoBehaviour
{
    public Animator animator;
    // Use this for initialization
    void Start()
    {


    }
    void StopLight()
    {
        animator.SetBool("lightTeleportOn", false);

    }

   
}

   
