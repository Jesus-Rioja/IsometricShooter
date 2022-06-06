using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject LevelSelectorPanel;
    public GameObject AudioPanel;
    public GameObject VideoPanel;
    public GameObject SettingsPanel;


    #region Panel Activation
    public void ActivatePanel(string panelToBeActivated)
    {
        MainPanel.SetActive(panelToBeActivated.Equals(MainPanel.name));
        LevelSelectorPanel.SetActive(panelToBeActivated.Equals(LevelSelectorPanel.name));
        SettingsPanel.SetActive(panelToBeActivated.Equals(SettingsPanel.name));
        AudioPanel.SetActive(panelToBeActivated.Equals(AudioPanel.name));
        VideoPanel.SetActive(panelToBeActivated.Equals(VideoPanel.name));
    }

    #endregion  

    public void quitGame()
    {
        Application.Quit();
    }

    
}
