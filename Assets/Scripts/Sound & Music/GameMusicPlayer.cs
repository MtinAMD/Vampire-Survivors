using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource gameMusic;
    public static float musicVolume = 1f;
    public static bool musicToggle = true;
    public static bool menuMusicToggle = true;
    [SerializeField] private GameObject toggle;
    [SerializeField] private GameObject slider;
    
    void Start()
    {
        musicVolume = MenuMusicPlayer.musicVolume;
        slider.GetComponent<Slider>().value = musicVolume;

        menuMusicToggle = MenuMusicPlayer.menuMusicToggle;
        musicToggle = MenuMusicPlayer.gameMusictoggle;

        if (musicToggle)
        {
            gameMusic.Play();
            toggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            toggle.GetComponent<Toggle>().isOn = false;
            gameMusic.Stop();
        }
    }
    
    private void Update()
    {
        gameMusic.volume = musicVolume;
    }
    
    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
    
    public void toggleGameMusic(bool toggle)
    {
        if (toggle)
        {
            gameMusic.Play();
            musicToggle = true;
        }
        else
        {
            gameMusic.Stop();
            musicToggle = false;
        }
    }
}
