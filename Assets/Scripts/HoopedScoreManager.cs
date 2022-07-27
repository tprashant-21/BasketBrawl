using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HoopedScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BasketBall"))
        {
            ScoreKeeper.score += 3;
            // ScoreKeeperscoreText.text = score.ToString();
        }
    }
}
