using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }   
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
