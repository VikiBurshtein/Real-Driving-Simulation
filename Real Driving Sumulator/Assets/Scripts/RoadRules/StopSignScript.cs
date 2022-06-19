using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSignScript : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Score;


    public void AlertCarDidntStop()
    {
        if (!Panel.activeSelf)
        {
            ScoreScript.ReduceScore(10);
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
