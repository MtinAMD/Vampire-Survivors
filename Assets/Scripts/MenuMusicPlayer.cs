using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource menuMusic;
    public static float musicVolume = 1f;
    public static bool gameMusictoggle = true;
    public static bool menuMusicToggle = true;
    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject menutoggle;
    [SerializeField] private GameObject gameToggle;
    
    private void Start()
    {
        musicVolume = GameMusicPlayer.musicVolume;
        slider.GetComponent<Slider>().value = musicVolume;
        gameMusictoggle = GameMusicPlayer.musicToggle;
        menuMusicToggle = GameMusicPlayer.menuMusicToggle;

        if (menuMusicToggle)
        {
            menuMusic.Play();
            menutoggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            menuMusic.Stop();
            menutoggle.GetComponent<Toggle>().isOn = false;
        }

        if (gameMusictoggle)
            gameToggle.GetComponent<Toggle>().isOn = true;
        else
            gameToggle.GetComponent<Toggle>().isOn = false;
    }

    private void Update()
    {
        menuMusic.volume = musicVolume;
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }

    public void toggleMenuMusic(bool toggle)
    {
        if (toggle)
        {
            menuMusic.Play();
            menuMusicToggle = true;
        }
        else
        {
            menuMusic.Stop();
            menuMusicToggle = false;
        }
    }

    public void toggleGameMusic(bool toggle)
    {
        gameMusictoggle = toggle;
    }
}