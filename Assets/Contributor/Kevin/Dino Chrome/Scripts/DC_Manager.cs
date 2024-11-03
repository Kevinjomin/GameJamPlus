using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DC_Manager : MonoBehaviour
{
    public static DC_Manager Instance;

    public int score;
    public int goal;
    public TMP_Text scoreText;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        score = 0;
        InitializeUI();
        StartCoroutine(AddScoreAtIntervals());
    }

    private void InitializeUI()
    {
        scoreText.text = $"{score.ToString()} / 600";
    }

    private IEnumerator AddScoreAtIntervals()
    {
        while (true)
        {
            AddScore(1);
            yield return new WaitForSeconds(0.1f);
        }
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
        scoreText.text = $"{score:D4}  / 600";
    }
}
