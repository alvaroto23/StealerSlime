using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class AudioClipClass
{
    public string clipName;

    public AudioClip clip;
    [Range(0f,1f)] public float volume;
    [Range(0f, 2f)] public float pitch;
    public bool loop;

    [HideInInspector] public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
