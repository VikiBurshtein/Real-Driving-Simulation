using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public GameObject Panel;
    private string selectedDifficulty = "Easy";
    private int pedestriansAmount = 0;
    public PedestrianSpawner pedestrianSpawner;

    public void SaveAndClosePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
        ScoreScript.ResetScore();
        pedestrianSpawner.UpdatePedestriansToSpawn(pedestriansAmount);
        pedestrianSpawner.Start();
        //SceneManager.LoadScene("SampleScene");
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

    public void updateDifficulty(string difficulty)
    {
        selectedDifficulty = difficulty;
    }

    public void updatePedestriansAmount(int number)
    {
        pedestriansAmount = number;
    }
}
