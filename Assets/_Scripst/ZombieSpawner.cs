using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Zombie[] zombieArray;

    bool spawn = true;
    float diff;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        diff = PlayerPrefsController.GetDifficulty();
        minSpawnDelay = minSpawnDelay / diff;
        maxSpawnDelay = maxSpawnDelay / diff;

        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnZombie();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnZombie()
    {
        var zombieIndex = Random.Range(0, zombieArray.Length);
        Spawn(zombieArray[zombieIndex]);
    }

    private void Spawn(Zombie zombie)
    {
        Zombie newZombie = Instantiate(zombie, transform.position, transform.rotation) as Zombie;
        newZombie.transform.parent = transform;
    }
}
