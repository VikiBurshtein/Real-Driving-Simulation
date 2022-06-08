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
        SceneManager.LoadScene("SampleScene");
    }
}
