using System.Collections.Generic;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    public GameObject player;
    public GameObject spawnPosition;

    public GameObject[] levels;

    private int currentLevel;

    private void Awake()
    {
        currentLevel = 0;
    }

    public void SetNextLevel()
    {
        if(levels.Length > currentLevel + 1) 
        {
            levels[currentLevel].SetActive(false);
            levels[currentLevel + 1].SetActive(true);
            currentLevel += 1;

            player.transform.position = spawnPosition.transform.position;
        }
    }
}
