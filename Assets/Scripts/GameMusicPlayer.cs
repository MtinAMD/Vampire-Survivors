using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource gameMusic;
    private float musicVolume = 1f;
    void Start()
    {
        gameMusic.Play();
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
            gameMusic.Play();
        else
            gameMusic.Stop();
    }
}
