using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableStopSign : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent interactAtion;
    public bool hasCarStopped = false;
    public CarController carController;

    // Update is called once per frame
    void Update()
    {
        if(isInRange && carController.getCarSpeed() == 0)
        {
            hasCarStopped = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasCarStopped)
        {
            interactAtion.Invoke();
            isInRange = false;
        }
    }
}
