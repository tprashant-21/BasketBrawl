using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class HitManager : MonoBehaviour
{
    int hitNumber = 0;

    public Animator animator;
    public NavMeshAgent agent;

    [SerializeField] Text hitScoreText;
    int hitScore = 0;

    bool isResetting;
    
    IEnumerator resetThreeShotDown()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(10);
        animator.SetBool("isThreeShotDown", false);
        agent.isStopped = false;
    }

    IEnumerator resetAfterAttack()
    {
        isResetting = true;
        yield return new WaitForSeconds(2.5f);
        isResetting = false;
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
        isResetting = false;
        hitScore = 0;
    }

    void Update() 
    {
        if(!isResetting && animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            hitScore += 3;
            hitScoreText.text = hitScore.ToString();
            StartCoroutine(resetAfterAttack());
        }
       
    }
}
