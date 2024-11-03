using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance;

    public int section = 1;
    public GameObject sectionOneObject;
    public GameObject sectionTwoObject;

    public List<string> minigamesForSection1 = new List<string>();

    public List<Monitor> monitors = new List<Monitor>();

    public Monitor currentMonitor;
    private int currentMonitorIndex;

    public Material screenOnMaterial;
    public Material screenOffMaterial;

    public List<Material> screenAnomalyMaterials = new List<Material>();

    public int totalLose;

    [SerializeField] GameEvent onSectionOneEnd;
    [SerializeField] GameEvent onSectionTwoStart;
    [SerializeField] GameEvent onGameWin;

    [SerializeField] AudioClip sectionTwoAmbience;
    [SerializeField] AudioClip subsectionBGM;
    [SerializeField] AudioClip staticSFX;

    [SerializeField] PlayableDirector winCutscene;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if(section == 1)
        {
            StartSectionOne();
        }
        else
        {
            StartSectionTwo();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Application.isEditor)
            {
                Debug.Log("Game win triggered! (editor only)");
                TriggerGameWin();
            }
        }
    }

    #region First section
    //these are codes for the first section
    private void StartSectionOne()
    {
        section = 1;
        sectionOneObject.SetActive(true);
        sectionTwoObject.SetActive(false);

        PickMonitorForSectionOne();
    }

    private void PickMonitorForSectionOne()
    {
        currentMonitor.TurnOff(screenOffMaterial);
        currentMonitor.TurnOn(screenOnMaterial, minigamesForSection1[0]);
    }

    #endregion

    #region Sub section
    private void StartSubSection()
    {
        currentMonitor.TurnOff(screenOffMaterial);
        currentMonitor.TurnOn(screenOnMaterial, "SubSection");

        SoundManager.Instance.PlayBGM(subsectionBGM);
    }

    public void TriggerSectionTwo()
    {
        if(section < 2)
        {
            StartSectionTwo();
        }
        else
        {
            Debug.LogWarning("Invalid section number");
        }
    }
    #endregion

    private void StartSectionTwo()
    {
        section = 2;
        sectionOneObject.SetActive(false);
        sectionTwoObject.SetActive(true);
        SoundManager.Instance.PlayBGM(sectionTwoAmbience);

        currentMonitor = null;
        Invoke("PickNewMonitor", 5f);
    }

    public void PickNewMonitor()
    {
        if (currentMonitor != null) currentMonitor.TurnOff(screenOffMaterial);

        currentMonitorIndex = GetNewMonitorIndex();
        currentMonitor = monitors[currentMonitorIndex];

        SoundManager.Instance.PlaySFXFromMonitor(staticSFX);
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
        if(section > 1)
        {
            RemoveMonitorFromList(currentMonitor);
            if (monitors.Count <= 0)
            {
                Win();
            }
            else
            {
                PickNewMonitor();
            }
        }
        else
        {
            minigamesForSection1.Remove(minigamesForSection1[0]);
            if(minigamesForSection1.Count <= 0)
            {
                StartSubSection();
            }
            else
            {
                PickMonitorForSectionOne();
            }
        }
    }

    public void TriggerGameLose()
    {
        if (section > 1)
        {
            totalLose++;
            if (totalLose >= 10)
            {
                Lose();
            }
            PickNewMonitor();
        }
        else
        {
            PickMonitorForSectionOne();
        }
    }

    private void Win()
    {
        Debug.Log("Game win");
        onGameWin.TriggerEvent();

        SoundManager.Instance.StopBGM();
        winCutscene.Play();
        winCutscene.stopped += OnWinCutsceneEnd; //call when cutscene ends

        sectionOneObject.SetActive(true);
        sectionTwoObject.SetActive(false);
    }

    private void OnWinCutsceneEnd(PlayableDirector director)
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    private void Lose()
    {
        Debug.Log("Game lost");
        SceneManager.LoadSceneAsync("Menu");
    }
}