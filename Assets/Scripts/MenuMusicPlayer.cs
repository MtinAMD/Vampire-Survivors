using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource menuMusic;
    [SerializeField] private AudioSource gameMusic;
    private float musicVolume = 1f;

    private void Start()
    {
        menuMusic.Play();
    }

    private void Update()
    {
        menuMusic.volume = musicVolume;
        gameMusic.volume = musicVolume;
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }

    public void toggleMenuMusic(bool toggle)
    {
        if (toggle)
            menuMusic.Play();
        else 
            menuMusic.Stop();
    }

    public void toggleGameMusic(bool toggle)
    {
        if (toggle)
            gameMusic.enabled = true;
        else
            gameMusic.enabled = false;
    }
}