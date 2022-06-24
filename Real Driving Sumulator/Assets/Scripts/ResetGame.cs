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
    public List<GameObject> Signs;
    public List<GameObject> Lanes;
    public List<GameObject> TesterDirections;
    public ScoreScript ScoreScript;

    public void SaveAndClosePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
        ScoreScript.ResetScore();
        pedestrianSpawner.UpdatePedestriansToSpawn(pedestriansAmount);
        pedestrianSpawner.Start();

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
        //selectedDifficulty = difficulty;
        if (difficulty == "Easy")
        {
            foreach (var sign in Signs)
            {
                sign.SetActive(false);
            }
            foreach (var lane in Lanes)
            {
                lane.SetActive(false);
            }
            foreach (var sign in TesterDirections)
            {
                sign.SetActive(false);
            }
        } else {
            foreach(var sign in Signs)
            {
                sign.SetActive(true);
            }

            foreach (var sign in TesterDirections)
            {
                sign.SetActive(true);
            }

            if (difficulty == "Difficult")
            {
                foreach (var lane in Lanes)
                {
                    lane.SetActive(true);
                }
            }
                
        }
    }

    public void updatePedestriansAmount(int number)
    {
        pedestriansAmount = number;
    }
}
