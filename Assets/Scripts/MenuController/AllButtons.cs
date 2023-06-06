using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllButtons : MonoBehaviour
{
    public Slider musicSlider;
    public GameObject gController;
    public void Awake()
    {
        gController = GameObject.Find("MenuController");
        if (gController == null) return;
        AudioSource music = gController.GetComponent<AudioSource>();
        musicSlider.value = music.volume;
    }

    public void ExitSecene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void changeVol(float vol)
    {
        if (gController == null) return;
        AudioSource music = GameObject.Find("MenuController").GetComponent<AudioSource>();
        music.volume = vol;
    }

}
