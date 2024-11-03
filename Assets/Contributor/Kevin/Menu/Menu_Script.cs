using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitButton()
    {
        Debug.Log("Application quitted!");
        Application.Quit();
    }
}
