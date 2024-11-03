using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource audioBGM;

    private void Awake()
    {
        Instance = this;

        audioBGM = GetComponent<AudioSource>();
        audioBGM.loop = true;
    }

    public void PlayBGM(AudioClip bgm)
    {
        if (audioBGM.clip != bgm)
        {
            audioBGM.Stop();
            audioBGM.clip = bgm;
            audioBGM.Play();
        }
    }

    public void StopBGM()
    {
        audioBGM.Stop();
        audioBGM.clip = null;
    }

    public void PlaySFX(AudioClip clip, Transform _transform, bool is3D)
    {
        GameObject soundObject = new GameObject("Sound");
        soundObject.transform.position = _transform.position;

        AudioSource source = soundObject.AddComponent<AudioSource>();
        source.clip = clip;

        if (is3D)
        {
            source.spatialBlend = 1; // Set to 3D
        }
        else
        {
            source.spatialBlend = 0; // Set to 2D
        }

        source.Play();

        Destroy(soundObject, clip.length);
    }

    public void PlaySFXFromMonitor(AudioClip clip)
    {
        GameObject soundObject = new GameObject("Sound");
        soundObject.transform.position = MinigameManager.Instance.currentMonitor.gameObject.transform.position;

        AudioSource source = soundObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.spatialBlend = 1;

        source.Play();

        Destroy(soundObject, clip.length);
    }
}
