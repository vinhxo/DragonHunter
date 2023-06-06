using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource MenuMusic, GameMusic, VictoryMusic;

    public AudioSource[] sfx;

    public Slider muSlider;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        muSlider.value = sfx[0].volume;
    }

    private void Update()
    {
        muSlider.value = sfx[0].volume;
    }
    public void PlayMenuMusic()
    {
        if (GameMusic.isPlaying)
        {
            GameMusic.Stop();
        }
        MenuMusic.Play();
    }
    public void PlayGameMusic()
    {
        if (MenuMusic.isPlaying)
        {
            MenuMusic.Stop();
        }
        GameMusic.Play();
    }

    public void PlayVictoryGameMusic()
    {
        if (MenuMusic.isPlaying || GameMusic.isPlaying)
        {
            MenuMusic.Stop();
            GameMusic.Stop();
        }
        VictoryMusic.Play();
    }

    public void PlaySfx(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }

    public void changeVol(float vol)
    {
        foreach (AudioSource music in sfx)
        {
            music.volume = vol;
        }
    }
}
