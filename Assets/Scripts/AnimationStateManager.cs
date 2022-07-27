using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AnimationStateManager : MonoBehaviour
{
    Animator animator;
    public NavMeshAgent agent;

    // bool isThreeShotDown;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // agent = GetComponent<NavMeshAgent>();
    }

    
    // Update is called once per frame
    void Update()
    {

        bool isStopped = (agent.remainingDistance <= agent.stoppingDistance);

        if(isStopped)
        {
            animator.SetBool("isNear", true);
        }

        if(!isStopped)
        {
            animator.SetBool("isNear", false);
        }

        // if(animator.GetCurrentAnimatorStateInfo(0).IsName("death"))
        // {
        // }



    }
}
