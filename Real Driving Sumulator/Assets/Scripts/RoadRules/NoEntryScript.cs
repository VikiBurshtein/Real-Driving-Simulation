using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEntryScript : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Score;

    public void OnCollisionEnter(Collision collision)
    {
        if (!Panel.activeSelf && collision.gameObject.CompareTag("Player"))
        {
            ScoreScript.ReduceScore(9);
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
