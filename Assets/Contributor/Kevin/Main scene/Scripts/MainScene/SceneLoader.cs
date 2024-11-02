using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void LoadMinigameScene(string sceneName)
    {
        //Debug.Log($"Loading scene {sceneName}");
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadMinigameScene(string sceneName)
    {
        //Debug.Log($"Unloading scene {sceneName}");
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
