using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedScript : MonoBehaviour
{
    public CarController carController;
    Text speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speed.text = "speed: " + carController.getCarSpeed().ToString() + "km/h";
    }

}
