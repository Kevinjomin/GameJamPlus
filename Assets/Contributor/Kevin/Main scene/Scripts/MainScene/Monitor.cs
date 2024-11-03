using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monitor : MonoBehaviour
{
    public GameObject screen;
    public string sceneName;

    public void TurnOn(Material material, string _sceneName = null) //_sceneName is only used for first section
    {
        screen.GetComponent<Renderer>().material = material;
        if(_sceneName != null)
        {
            sceneName = _sceneName;
        }
        SceneLoader.Instance.LoadMinigameScene(sceneName);
    }

    public void TurnOff(Material material)
    {
        screen.GetComponent<Renderer>().material = material;
        if (SceneLoader.Instance.IsSceneLoaded(sceneName))
        {
            SceneLoader.Instance.UnloadMinigameScene(sceneName);
        }
    }
}
