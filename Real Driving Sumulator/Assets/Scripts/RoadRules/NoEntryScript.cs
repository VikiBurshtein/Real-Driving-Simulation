using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEntryScript : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Score;
    public ScoreScript ScoreScript;

    public void AlertNoEntryPass()
    {
        if (!Panel.activeSelf)
        {
            ScoreScript.ReduceScore(10, "TrafficSign");
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
