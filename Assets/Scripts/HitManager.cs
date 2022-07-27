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
    public AudioSource enemyPunchingSound;


    public Animator animator;
    public NavMeshAgent agent;

    [SerializeField] Text hitScoreText;
    public static int enemyScore = 0;

    bool isResetting;

    IEnumerator resetDeath()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(2);
        animator.SetBool("isThreeShotDown", false);
        yield return new WaitForSeconds(9f);
        agent.isStopped = false;
    }
    

    IEnumerator resetAfterAttack()
    {
        isResetting = true;
        enemyPunchingSound.Play();
        yield return new WaitForSeconds(2.2f);
        isResetting = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("fist"))
        {
            hitNumber++;
            // Debug.Log("fist detected!");
            headHitSound.Play();
            if(hitNumber >= 3)
            {
                animator.SetBool("isThreeShotDown", true);
                hitNumber = 0;
                StartCoroutine(resetDeath());
            }
            else
            {
                animator.SetTrigger("HeadHit");
            }
        }

        if(other.gameObject.CompareTag("objects"))
        {
            hitNumber += 3;
            animator.SetTrigger("HeadHit");
            headHitObjectSound.Play();
            animator.SetBool("isThreeShotDown", true);
            StartCoroutine(resetDeath());
            hitNumber = 0;

            
        }
    }

    
    void Start() 
    {
        // animator = GetComponent<Animator>();
        isResetting = false;
        enemyScore = 0;


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
