using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyBirdGameManager : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
    private int objectives = 15;

    void Start()
    {
        UpdateScoreText();
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Pipes")
        {
            Debug.Log("KETABRAK!");
            MinigameManager.Instance.TriggerGameLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Point")
        {
            score++;
            UpdateScoreText();
            if (score >= objectives)
            {
                MinigameManager.Instance.TriggerGameWin();
            }
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score : " + score;
    }
}
