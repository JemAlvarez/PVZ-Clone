using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "Master Volume";
    const string DIFFICULTY_KEY = "Difficulty";

    const float MIN_VOL = 0f;
    const float MAX_VOL = 1f;
    const float MIN_DIFF = 1f;
    const float MAX_DIFF = 3f;

    public static void SetMasterVolume(float vol)
    {
        if (vol >= MIN_VOL && vol <= MAX_VOL)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, vol);
        }
        else
        {
            Debug.LogError("Master volume is out of range.");
        }
    }

    public static void SetDifficulty(float diff)
    {
        if (diff >= MIN_DIFF && diff <= MAX_DIFF)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        }
        else
        {
            Debug.LogError("Master volume is out of range.");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
