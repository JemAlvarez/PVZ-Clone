using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] int sunCost = 100;

    public void AddSun(int amount)
    {
        FindObjectOfType<SunDisplay>().AddSun(amount);
    }

    public int GetSunCost()
    {
        return sunCost;
    }
}
