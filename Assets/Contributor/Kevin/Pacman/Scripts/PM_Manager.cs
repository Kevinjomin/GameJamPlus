using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PM_Manager : MonoBehaviour
{
    public static PM_Manager Instance;

    public int score;
    public int goal;
    public TMP_Text scoreText;

    public GameObject pelletsContainer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        goal = pelletsContainer.transform.childCount;
        InitializeUI();
    }

    private void InitializeUI()
    {
        scoreText.text = $"Score : {score.ToString()}";
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
