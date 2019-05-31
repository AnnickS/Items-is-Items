using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject pauseMenu;
    public KeyCode pauseKey;
    protected static float defaultGameSpeed = 1;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
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
        defaultGameSpeed = Time.timeScale;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        isGamePaused = false;
        Time.timeScale = defaultGameSpeed;
        pauseMenu.SetActive(false);
    }
}
