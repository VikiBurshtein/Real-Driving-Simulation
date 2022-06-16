using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private static int scoreAtStart = 100;
    public static int scoreValue = scoreAtStart;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreValue.ToString();
    }

    public static void ReduceScore(int amount)
    {
        scoreValue -= amount;
    }

    public static void ResetScore()
    {
        scoreValue = scoreAtStart;
    }
}
