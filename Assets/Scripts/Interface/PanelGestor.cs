using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelGestor : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuPanel;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public void PauseButton()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        PauseMenuPanel.SetActive(true);
    }

    public void ActivateWinPanel()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        WinPanel.SetActive(true);
    }

    public void ActivateLosePanel()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        LosePanel.SetActive(true);
    }

    public void ResumeButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        PauseMenuPanel.SetActive(false);
    }
}
