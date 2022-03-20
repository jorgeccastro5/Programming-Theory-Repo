using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject controlsScreen;
    private bool isGamePaused = false;
    private bool isControlsScreenShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        isGamePaused = false;
        isControlsScreenShowing = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isControlsScreenShowing)
            {
                ShowControlsHandler();
            }
            else
            {
                PauseGameHandler();
            }
        }

    }

    public void PauseGameHandler()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
        }
    }

    public void ShowControlsHandler()
    {
        isControlsScreenShowing = !isControlsScreenShowing;
        if (isGamePaused)
        {
            if (isControlsScreenShowing)
            {
                pauseScreen.SetActive(false);
                controlsScreen.SetActive(true);
            }
            else
            {
                pauseScreen.SetActive(true);
                controlsScreen.SetActive(false);
            }
            
        }
    }

    public bool GetPausedGameStatus()
    {
        return isGamePaused;
    }
}
