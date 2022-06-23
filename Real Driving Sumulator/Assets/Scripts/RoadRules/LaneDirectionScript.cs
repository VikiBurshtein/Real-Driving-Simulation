using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneDirectionScript : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Score;
    private bool firstTriggerEntered = false;
    public ScoreScript ScoreScript;

    public void AlertTriggerEntered()
    {
        Debug.Log(firstTriggerEntered);
        if (!Panel.activeSelf && firstTriggerEntered)
        {
            ScoreScript.ReduceScore(10, "WrongLane");
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void UpdateFirstTriggerEntered(bool Value)
    {
        firstTriggerEntered = Value;
    }
}
