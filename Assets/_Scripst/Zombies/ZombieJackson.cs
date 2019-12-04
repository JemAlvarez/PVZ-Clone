using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieJackson : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Plant>())
        {
            GetComponent<Zombie>().Attack(otherObject);
        }
    }
}
