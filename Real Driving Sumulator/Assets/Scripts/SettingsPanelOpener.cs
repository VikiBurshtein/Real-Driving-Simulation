using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanelOpener : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        if(Panel != null)
        {
            Time.timeScale = 0;
            Panel.SetActive(true);
        }
    }

    public void CancelAndClosePanel()
    {
        if (Panel != null)
        {
            Time.timeScale = 1;
            Panel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
