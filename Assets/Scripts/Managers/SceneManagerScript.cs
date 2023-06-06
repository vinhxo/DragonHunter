using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    BossState bossState;
    public GameObject bossHealthBar;
    public CameraFollow cam;
    public LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.Find("Managers").GetComponent<LevelManager>();
        bossState = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossState>();

    }
    private void Start()
    {
        /*AudioManager.instance.PlayGameMusic();*/
        cam = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }


    // Update is called once per frame
    void Update()
    {
        if (bossState.state == BossState.State.SLEEP || bossState.state == BossState.State.DEATH)
        {
            if (bossHealthBar != null)
            {
                bossHealthBar.SetActive(false);

            }
        }
        else
        {
            if (bossHealthBar != null)
            {
                bossHealthBar.SetActive(true);
            }
        }
        if (Boss.bossDeath == true)
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemys.Length > 0)
            {
                foreach(GameObject ene in enemys)
                {
                    ene.GetComponent<Animator>().SetBool("Death", true);
                }
            }
            
            
            cam.followDistance = 4;
            cam.followHeight = 4;
            Invoke("backMenu", 10);
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            levelManager.Level = 0;
            levelManager.CurrentExp = 0;
            Invoke("RestartScene", 10);
        }
    }
    void RestartScene()
    {
        SceneManager.LoadScene(1);
    }

    void backMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
