using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class pausecontroller : MonoBehaviour
{
    public Slider master, bgm, sfx;
    public AudioMixer audi;

    public GameObject childobject;

    void Start(){
        DontDestroyOnLoad(gameObject);
    }

    public void changevol(){
        audi.SetFloat("MASTER", master.value);
        audi.SetFloat("BGM", bgm.value);
        audi.SetFloat("SFX", sfx.value);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            setpasue();
        }
    }

    public void setpasue(){
        if(childobject.activeSelf){
            childobject.SetActive(false);
            Time.timeScale = 1;
            Scene scene = SceneManager.GetActiveScene();
            Cursor.lockState = CursorLockMode.None;
            if(scene.name == "MainScene"){
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            return;
        }else{
            childobject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
