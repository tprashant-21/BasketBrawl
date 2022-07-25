using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitManager : MonoBehaviour
{
    int hitNumber = 0;

    Animator animator;
    bool isHit;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("fist"))
        {
            hitNumber++;
            isHit = true;
        }

    }

    void Start() 
    {
        animator = GetComponent<Animator>();
    }

    void Update() 
    {

        if(isHit)
        {
            animator.SetBool("isHeadHit", true);
        }
        if(!isHit)
        {
            animator.SetBool("isHeadHit", false);
        }

        if(hitNumber == 3)
        {
            animator.SetBool("isThreeShotDown", true);
        }
        
        if(hitNumber != 3)
        {
            animator.SetBool("isThreeShotDown", false);
        }
    }
}
