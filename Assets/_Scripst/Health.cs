using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDmg(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX)
        {
            return;
        }

        var vfx = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(vfx, 1f);
    }
}
