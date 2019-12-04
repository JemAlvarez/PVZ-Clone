using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int loadDelay = 3;

    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadMenu());
        }
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(loadDelay);
        LoadNextScene();
    }

    public void  LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu Screen");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("Lose");
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
