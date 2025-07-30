using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stop : MonoBehaviour
{
    public GameObject Controls;
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowControls()
    {
        Controls.SetActive(true);
    }

    public void HideControls()
    {
        Controls.SetActive(false);
    }

    public void ToggleControls() // ✅ Tambahan
    {
        Controls.SetActive(!Controls.activeSelf);
    }

    void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenuUI.SetActive(true);
        ShowControls();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuUI.SetActive(false);
        HideControls();
    }
}
