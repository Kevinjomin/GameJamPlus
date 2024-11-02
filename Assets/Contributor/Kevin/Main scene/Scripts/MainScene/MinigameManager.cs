using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance;

    public int section = 1;

    public List<Monitor> monitors = new List<Monitor>();

    private Monitor currentMonitor;
    private int currentMonitorIndex;

    public Material screenOnMaterial;
    public Material screenOffMaterial;

    public List<Material> screenAnomalyMaterials = new List<Material>();

    public int totalLose;

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
        if (currentMonitor != null) currentMonitor.TurnOff(screenOffMaterial);

        currentMonitorIndex = GetNewMonitorIndex();
        currentMonitor = monitors[currentMonitorIndex];

        currentMonitor.TurnOn(GetScreenMaterial());
    }

    private Material GetScreenMaterial()
    {
        float random = Random.Range(0, 100);
        if(random < (5f * totalLose))
        {
            int randomIndex = Random.Range(0, screenAnomalyMaterials.Count);
            return screenAnomalyMaterials[randomIndex];
        }
        return screenOnMaterial;
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

    private void RemoveMonitorFromList(Monitor monitorToRemove)
    {
        monitors.Remove(monitorToRemove);
    }

    public void TriggerGameWin()
    {
        RemoveMonitorFromList(currentMonitor);
        if(monitors.Count <= 0)
        {
            Win();
        }
        else
        {
            PickNewMonitor();
        }
    }

    public void TriggerGameLose()
    {
        totalLose++;
        if(totalLose >= 10)
        {
            Lose();
        }
        PickNewMonitor();
    }

    private void Win()
    {
        Debug.Log("Game win");
    }

    private void Lose()
    {
        Debug.Log("Game lost");
    }
}