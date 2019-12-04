using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SunDisplay : MonoBehaviour
{
    [SerializeField] int suns = 75;
    [SerializeField] float idleSunsDelay = 4f;
    TextMeshProUGUI sunText;
    float diff;

    private void Start()
    {
        diff = PlayerPrefsController.GetDifficulty();

        suns = suns * Mathf.RoundToInt(diff);

        sunText = GetComponent<TextMeshProUGUI>();

        UpdateDisplay();
        StartCoroutine(IdleSuns());

    }

    IEnumerator IdleSuns()
    {
        while (true)
        {
            yield return new WaitForSeconds(idleSunsDelay);
            suns += 25;
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        sunText.text = suns.ToString();
    }

    public void AddSun(int amount)
    {
        suns += amount;
        UpdateDisplay();
    }

    public bool HasEnoughSun(int amount)
    {
        return suns >= amount;
    }

    public void SpendSuns(int amount)
    {
        if (suns >= amount)
        {
            suns -= amount;
            UpdateDisplay();
        }
    }
}
