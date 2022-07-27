using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreKeeper : MonoBehaviour
{
    public static int score = 0;

    [SerializeField] Text scoreText;

    public bool isOnMultipleCollisionTimer;

    IEnumerator resetCollisionTimer()
    {
        isOnMultipleCollisionTimer = true;
        yield return new WaitForSeconds(2);
        isOnMultipleCollisionTimer = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        // Debug.Log("The trigger is working");
        if(other.gameObject.CompareTag("BasketBall"))
        {
            if(!isOnMultipleCollisionTimer)
            {
                score += 2;
                scoreText.text = score.ToString();
                StartCoroutine(resetCollisionTimer());
            }
            

            // Debug.Log("BasketBall detected");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isOnMultipleCollisionTimer = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
