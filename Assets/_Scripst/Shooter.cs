using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    ZombieSpawner myLaneSpawner;
    Animator plantAnimator;

    private void Start()
    {
        plantAnimator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update()
    {
        if (ZombieInLane())
        {
            plantAnimator.SetBool("isAttacking", true);
        }
        else
        {
            plantAnimator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        var spawners = FindObjectsOfType<ZombieSpawner>();

        foreach (ZombieSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool ZombieInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        return true;
    }

    public void Shoot()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
