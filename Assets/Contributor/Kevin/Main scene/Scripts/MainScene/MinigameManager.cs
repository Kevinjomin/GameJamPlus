using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance;

    public List<Monitor> monitors = new List<Monitor>();

    public Monitor currentMonitor;
    public int currentMonitorIndex;

    public int score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentMonitor = null;
        PickNewMonitor();
    }

    public void PickNewMonitor()
    {
        if (currentMonitor != null) currentMonitor.TurnOff();

        currentMonitorIndex = GetNewMonitorIndex();
        currentMonitor = monitors[currentMonitorIndex];

        currentMonitor.TurnOn();
    }

    private int GetNewMonitorIndex()
    {
        if (monitors.Count <= 1) return 0;


        List<int> availableIndex = new List<int>();
        for (int i = 0; i < monitors.Count; i++)
        {
            if (i != currentMonitorIndex) availableIndex.Add(i);
        }

        int randomIndex = Random.Range(0, availableIndex.Count);
        return availableIndex[randomIndex];
    }

    public void TriggerGameWin()
    {
        score++;
        PickNewMonitor();
    }

    public void TriggerGameLose()
    {
        score--;
        PickNewMonitor();
    }
}
