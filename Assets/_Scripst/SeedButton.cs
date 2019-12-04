using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedButton : MonoBehaviour
{
    [SerializeField] Material selected;
    [SerializeField] Material notSelected;
    [SerializeField] Plant plantPrefab;

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<SeedButton>();
        foreach (SeedButton button in buttons)
        {
            button.GetComponent<MeshRenderer>().material = notSelected;
        }

        GetComponent<MeshRenderer>().material = selected;
        FindObjectOfType<PlantSpawner>().SetSelectedPlant(plantPrefab);
    }
}
