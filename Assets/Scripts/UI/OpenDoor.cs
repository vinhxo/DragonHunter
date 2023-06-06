using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private LevelManager levelManager;
    [SerializeField] private int level;


    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(levelManager.Level >= level)
        {
            Destroy(this.gameObject, 1);
        }
    }
}
