using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Range (0f, 5f)] float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().ZombieSpawned();
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (!levelController) { return; }
        FindObjectOfType<LevelController>().ZombieKilled();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMoveSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void DamageCurrentTarget(float dmg)
    {
        if (!currentTarget) { return;  }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDmg(dmg);
        }
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }
}
