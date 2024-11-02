using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SS_Manager : MonoBehaviour
{
    public static SS_Manager Instance;

    public int score;
    public int goal;

    public TMP_Text scoreText;
    public TMP_Text goalText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        scoreText.text = $"Score : {score.ToString()}";
        goalText.text = $"Goal : {goal.ToString()}";

    }

    public void AddScore(int _score)
    {
        score += _score;
        if (score >= goal)
        {
            MinigameManager.Instance.TriggerGameWin();
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreText.text = $"Score : {score.ToString()}";
    }
}
