using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    public GameObject TesterSaysPanel;
    public GameObject IgnoredTesterPanel;
    public ScoreScript ScoreScript;

    public void TesterSays()
    {
        if (!TesterSaysPanel.activeSelf)
        {
            TesterSaysPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void IgnoredTester()
    {
        if (!IgnoredTesterPanel.activeSelf)
        {
            ScoreScript.ReduceScore(10, "IgnoredTester");
            IgnoredTesterPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
