using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject pauseMenu;
    public KeyCode pauseKey;
    protected static float defaultTimeScale;

    void Start()
    {
        pauseMenu.SetActive(false);
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
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        isGamePaused = false;
        Time.timeScale = defaultTimeScale;
        pauseMenu.SetActive(false);
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
}
