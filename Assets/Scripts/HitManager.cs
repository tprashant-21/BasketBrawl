using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitManager : MonoBehaviour
{
    int hitNumber = 0;

    public Animator animator;
    


    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("fist"))
        {
            hitNumber++;
            animator.SetTrigger("HeadHit");
            if(hitNumber == 3)
            {

                animator.SetBool("isThreeShotDown", true);
                hitNumber = 0;
            }
            else
            {
                animator.SetBool("isThreeShotDown", false);
            
            }
        }
        

        
        

    }

    void Start() 
    {
        // animator = GetComponent<Animator>();
    }

    void Update() 
    {

    }
}
