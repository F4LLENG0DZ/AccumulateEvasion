using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    int scorePoints;
    public Text ScorePoints;
    public Text HighScorePoints;

    // Start is called before the first frame update
    void Start()
    {
        HighScorePoints.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ScorePoints.text = scorePoints.ToString();

        if (scorePoints > PlayerPrefs.GetInt("HighScore", 0)) 
        {
            PlayerPrefs.SetInt("HighScore", scorePoints);
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PlusPoint")
        {
            scorePoints += 300;
            Destroy(collision.gameObject);
            FindObjectOfType<SoundEffectPlayer>().GamePlusPointsSFX();
        }
        if (collision.gameObject.tag == "AddHealthPoint")
        {
            scorePoints += 400; 
            Destroy(collision.gameObject);
            FindObjectOfType<SoundEffectPlayer>().GameAddHealthPointsSFX(); 
        }
        if (collision.gameObject.tag == "MinusPoint")
        {
            scorePoints -= 600;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "BigObstacles")
        {
            scorePoints -= 100;
            Destroy(collision.gameObject);
        }
    }
}
