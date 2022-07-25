using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreKeeper : MonoBehaviour
{
    int score = 0;

    [SerializeField] Text scoreText;


    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("BasketBall"))
        {
            score += 1;
            scoreText.text = score.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
