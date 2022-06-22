using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    public GameObject Panel;

    public void TesterSays()
    {
        if (!Panel.activeSelf)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
