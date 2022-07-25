using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HitManager : MonoBehaviour
{
    int hitNumber = 0;

    public Animator animator;
    public NavMeshAgent agent;
    
    IEnumerator resetThreeShotDown()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(10);
        animator.SetBool("isThreeShotDown", false);
        agent.isStopped = false;
    }

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
                StartCoroutine(resetThreeShotDown());
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
