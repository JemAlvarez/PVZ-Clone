using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [Tooltip("Our level time in seconds")]
    [SerializeField] float levelTime = 40f;
    bool triggerLevelFinished = false;
    float diff;


    // Start is called before the first frame update
    void Start()
    {
        diff = PlayerPrefsController.GetDifficulty();
        levelTime = levelTime * diff;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().SetTimerHasFinished();
            triggerLevelFinished = true;
        }
    }
}
