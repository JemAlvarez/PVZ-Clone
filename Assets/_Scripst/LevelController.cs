using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseDialog;
    [SerializeField] float waitToLoad = 4f;
    int numberOfZombies = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseDialog.SetActive(false);
    }

    public void ZombieSpawned()
    {
        numberOfZombies++;
    }

    public void ZombieKilled()
    {
        numberOfZombies--;

        if (numberOfZombies <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void SetTimerHasFinished()
    {
        levelTimerFinished = true;
        StopZombieSpawners();
    }

    public void Lose()
    {
        loseDialog.SetActive(true);
        Time.timeScale = 0;
    }

    private void StopZombieSpawners()
    {
        ZombieSpawner[] spawnerArray = FindObjectsOfType<ZombieSpawner>();
        foreach (ZombieSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
}
