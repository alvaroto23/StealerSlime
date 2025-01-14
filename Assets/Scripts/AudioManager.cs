using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClipClass[] clipSounds;
    private float t;
    private float duration = 2f;

    private void Awake()
    {
        foreach (AudioClipClass sounds in clipSounds)
        {
            sounds.audioSource = gameObject.AddComponent<AudioSource>();
            sounds.audioSource.clip = sounds.clip;
            sounds.audioSource.volume = sounds.volume;
            sounds.audioSource.pitch = sounds.pitch;
            sounds.audioSource.loop = sounds.loop;
        }
    }


    public void PlayAudio(string name)
    {
        AudioClipClass sounds = Array.Find(clipSounds,clipSounds => clipSounds.clipName == name);
        if(sounds == null)
        {
            Debug.LogWarning("Sound" + name + " not found to play");
            return;
        }
        sounds.audioSource.Play();
        
    }

    public void PlayOneShotAudio(string name)
    {
        AudioClipClass sounds = Array.Find(clipSounds, clipSounds => clipSounds.clipName == name);
        if (sounds == null)
        {
            Debug.LogWarning("Sound" + name + " not found to one shot");
            return;
        }
        sounds.audioSource.PlayOneShot(sounds.clip);

    }

    public void StopAudio(string name)
    {
        AudioClipClass sounds = Array.Find(clipSounds, clipSounds => clipSounds.clipName == name);
        if (sounds == null)
        {
            Debug.LogWarning("Sound" + name + " not found to stop");
            return;
        }

        while(t < duration)
        {
            sounds.audioSource.volume = Mathf.Lerp(sounds.audioSource.volume, 0, t);
            t += Time.deltaTime / duration;
        }
        

    }

    public void StopLoop(string name)
    {
        AudioClipClass sounds = Array.Find(clipSounds, clipSounds => clipSounds.clipName == name);
        if (sounds == null)
        {
            Debug.LogWarning("Sound" + name + " not found to stop");
            return;
        }

        sounds.audioSource.loop = false;
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            FindObjectOfType<AudioManager>().PlayAudio("Intro Background");
        }
        else if (SceneManager.GetActiveScene().name == "Level1")
        {
            FindObjectOfType<AudioManager>().PlayAudio("Background Music");
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            FindObjectOfType<AudioManager>().PlayAudio("Background Music 1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
