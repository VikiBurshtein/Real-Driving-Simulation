using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelOpener : MonoBehaviour
{
    public GameObject GameOverPanel;
    public ScoreScript ScoreScript;

    public Text TotalGrade;
    public Text RandomGradeText;
    public Text PedestrianGradeText;
    public Text TrafficLightGradeText;
    public Text TrafficSignGradeText;
    public Text WrongLaneGradeText;
    public Text SpeedLimitGradeText;
    public Text IgnoredTesterGradeText;

    public void OpenPanel()
    {
        if (GameOverPanel != null)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);

            TotalGrade.text = ScoreScript.GetScore().ToString();
            var dict = ScoreScript.GetDictionary();
            RandomGradeText.text = dict["Random"].ToString();
            PedestrianGradeText.text = dict["Pedestrian"].ToString();
            TrafficLightGradeText.text = dict["TrafficLight"].ToString();
            TrafficSignGradeText.text = dict["TrafficSign"].ToString();
            WrongLaneGradeText.text = dict["WrongLane"].ToString();
            SpeedLimitGradeText.text = dict["SpeedLimit"].ToString();
            IgnoredTesterGradeText.text = dict["IgnoredTester"].ToString();
        }
    }
}
