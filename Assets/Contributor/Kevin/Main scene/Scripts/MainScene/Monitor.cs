using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    public GameObject screen;
    public string sceneName;

    public Material screenOnMaterial;
    public Material screenOffMaterial;

    public void TurnOn()
    {
        screen.GetComponent<Renderer>().material = screenOnMaterial;
        SceneLoader.Instance.LoadMinigameScene(sceneName);
    }

    public void TurnOff()
    {
        screen.GetComponent<Renderer>().material = screenOffMaterial;
        SceneLoader.Instance.UnloadMinigameScene(sceneName);
    }

}
