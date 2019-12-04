using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBalloon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Plant>())
        {
            if (otherObject.tag == "Tallnut")
            {
                return;
            }
            else
            {
                GetComponent<Zombie>().Attack(otherObject);
            }
        }
    }
}
