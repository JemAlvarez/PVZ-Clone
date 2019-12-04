using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    Plant plant;

    private void OnMouseDown()
    {
        AttemptToPlacePlantAt(GetSquaredClicked());
    }

    public void SetSelectedPlant(Plant plantToSelect)
    {
        plant = plantToSelect;
    }

    private void AttemptToPlacePlantAt(Vector2 gridPos)
    {
        var SunDisplay = FindObjectOfType<SunDisplay>();
        int plantCost = plant.GetSunCost();

        if (SunDisplay.HasEnoughSun(plantCost))
        {
            SpawnePlant(gridPos);
            SunDisplay.SpendSuns(plantCost);
        }
    }

    private Vector2 GetSquaredClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = snapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 snapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX,newY);
    }

    private void SpawnePlant(Vector2 coord)
    {
        Plant newPlant = Instantiate(plant, coord, Quaternion.identity) as Plant;
    }
}
