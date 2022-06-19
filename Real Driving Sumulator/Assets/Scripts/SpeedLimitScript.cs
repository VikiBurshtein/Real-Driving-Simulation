using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedLimitScript : MonoBehaviour
{
    private static int speedLimitAtStart = 50;
    public static int speedLimitValue = speedLimitAtStart;
    Text speedLimit;
    public CarController carController;
    private bool lostPoints = false;
    public GameObject Panel;
    public GameObject Score;

    // Start is called before the first frame update
    void Start()
    {
        speedLimit = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speedLimit.text = "limit: " + speedLimitValue.ToString() + "km/h";
        if (carController.getCarSpeed() > speedLimitValue)
        {
            speedLimit.color = Color.red;
            if (carController.getCarSpeed() > speedLimitValue + 10)
            {
                AlertCarDidntStop();
                lostPoints = true;
            }
        } else
        {
            speedLimit.color = Color.white;
            lostPoints = false;
        }
    }
    public void AlertCarDidntStop()
    {
        if (!Panel.activeSelf && !lostPoints)
        {
            ScoreScript.ReduceScore(5);
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public static void UpdateSpeedLimit(int newValue)
    {
        speedLimitValue = newValue;
    }

    public static void ResetScore()
    {
        speedLimitValue = speedLimitAtStart;
    }
}
