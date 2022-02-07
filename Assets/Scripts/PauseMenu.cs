using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public static bool GameOver = false;

    public GameObject pauseMenuUI;

    public GameObject deathMenuUI;

    public GameObject winMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Resume();
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Pause();
            }
        }
    }

    public void win()
    {
        winMenuUI.SetActive(true);
        GameOver = true;
        Time.timeScale = 0f;
        GamePaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void Death()
    {
        deathMenuUI.SetActive(true);
        GameOver = true;
        Time.timeScale = 0f;
        GamePaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Retry()
    {
        deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Loading game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameOver = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
