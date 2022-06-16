using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public GameObject Panel;

    public void SaveAndClosePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
        ScoreScript.ResetScore();
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void CloseWithoutReseting()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
        Time.timeScale = 1;
    }
}
