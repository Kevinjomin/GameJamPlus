using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    public GameObject screen;
    public string sceneName;

    public void TurnOn(Material material)
    {
        screen.GetComponent<Renderer>().material = material;
        SceneLoader.Instance.LoadMinigameScene(sceneName);
    }

    public void TurnOff(Material material)
    {
        screen.GetComponent<Renderer>().material = material;
        SceneLoader.Instance.UnloadMinigameScene(sceneName);
    }

}
