using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class HitManager : MonoBehaviour
{
    int hitNumber = 0;

    public AudioSource headHitSound;
    public AudioSource headHitObjectSound;


    public Animator animator;
    public NavMeshAgent agent;

    [SerializeField] Text hitScoreText;
    int enemyScore = 0;

    bool isResetting;

    IEnumerator resetDeath()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(2);
        animator.SetBool("isThreeShotDown", false);
        StartCoroutine(resetAgentStop());
    }
    
    IEnumerator resetAgentStop()
    {
        yield return new WaitForSeconds(9);
        agent.isStopped = false;
    }

    IEnumerator resetAfterAttack()
    {
        isResetting = true;
        yield return new WaitForSeconds(3);
        isResetting = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("fist"))
        {
            hitNumber++;
            headHitSound.Play();
            animator.SetTrigger("HeadHit");
            if(hitNumber >= 3)
            {
                animator.SetBool("isThreeShotDown", true);
                hitNumber = 0;
                StartCoroutine(resetDeath());
            }
        }

        if(other.gameObject.CompareTag("objects"))
        {
            hitNumber += 5;
            animator.SetTrigger("HeadHit");
            headHitObjectSound.Play();
            if(hitNumber >= 3)
            {
                animator.SetBool("isThreeShotDown", true);
                hitNumber = 0;
                StartCoroutine(resetDeath());
            }
        }
    }

    
    void Start() 
    {
        // animator = GetComponent<Animator>();
        isResetting = false;
        enemyScore = 0;

        headHitSound = GetComponent<AudioSource>();
        headHitObjectSound = GetComponent<AudioSource>();


    }

    void Update() 
    {
        if(!isResetting && animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            enemyScore += 2;
            hitScoreText.text = enemyScore.ToString();
            StartCoroutine(resetAfterAttack());
        }
       
    }
}
