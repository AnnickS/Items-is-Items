using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject activeOnPause;
    public KeyCode pauseKey;
    protected static float defaultTimeScale;
    public string mainMenuSceneName = "MainMenu";

    void Start()
    {
        activeOnPause.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            Debug.Log("Pause Button was pressed");
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        isGamePaused = true;
        defaultTimeScale = Time.timeScale;
        Time.timeScale = 0;
        activeOnPause.SetActive(true);
    }

    public void Resume()
    {
        isGamePaused = false;
        Time.timeScale = defaultTimeScale;
        activeOnPause.SetActive(false);
    }

    public float getDefaultTimeScale()
    {
        if(isGamePaused)
        {
            return defaultTimeScale;
        }
        else
        {
            return Time.timeScale;
        }
    }

    public void RestartLevel()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Resume();
        StorageManager.SaveGameData();
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
