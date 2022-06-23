using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreAtStart = 100;
    public int scoreValue = scoreAtStart;
    private Dictionary<string, int> PointsLost = new Dictionary<string, int>();
    public GameObject GameOverPanel;

    public Text TotalGrade;
    public Text RandomGradeText;
    public Text PedestrianGradeText;
    public Text TrafficLightGradeText;
    public Text TrafficSignGradeText;
    public Text WrongLaneGradeText;
    public Text SpeedLimitGradeText;
    public Text IgnoredTesterGradeText;

    Text score;

    void Start()
    {
        score = GetComponent<Text>();
        PointsLost.Add("Random", 0);
        PointsLost.Add("Pedestrian", 0);
        PointsLost.Add("TrafficLight", 0);
        PointsLost.Add("TrafficSign", 0);
        PointsLost.Add("WrongLane", 0);
        PointsLost.Add("SpeedLimit", 0);
        PointsLost.Add("IgnoredTester", 0);
    }

    void Update()
    {
        score.text = scoreValue.ToString();
    }

    public  void ReduceScore(int amount, string cause)
    {
        Debug.Log(cause);
        Debug.Log(PointsLost[cause]);
        

        if (scoreValue >= amount)
        {
            scoreValue -= amount;
            PointsLost[cause] += amount;
        } else
        {
            PointsLost[cause] += scoreValue;
            scoreValue = 0;
            GameOverPanel.SetActive(true);

            TotalGrade.text = scoreValue.ToString();
            RandomGradeText.text = PointsLost["Random"].ToString();
            PedestrianGradeText.text = PointsLost["Pedestrian"].ToString();
            TrafficLightGradeText.text = PointsLost["TrafficLight"].ToString();
            TrafficSignGradeText.text = PointsLost["TrafficSign"].ToString();
            WrongLaneGradeText.text = PointsLost["WrongLane"].ToString();
            SpeedLimitGradeText.text = PointsLost["SpeedLimit"].ToString();
            IgnoredTesterGradeText.text = PointsLost["IgnoredTester"].ToString();
        }
    }

    public void ResetScore()
    {
        scoreValue = scoreAtStart;
        PointsLost = new Dictionary<string, int>();
        PointsLost.Add("Random", 0);
        PointsLost.Add("Pedestrian", 0);
        PointsLost.Add("TrafficLight", 0);
        PointsLost.Add("TrafficSign", 0);
        PointsLost.Add("WrongLane", 0);
        PointsLost.Add("SpeedLimit", 0);
        PointsLost.Add("IgnoredTester", 0);
    }

    public Dictionary<string, int> GetDictionary()
    {
        return PointsLost;
    }

    public int GetScore()
    {
        return scoreValue;
    }
}
