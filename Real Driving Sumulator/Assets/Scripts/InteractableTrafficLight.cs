using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableTrafficLight : MonoBehaviour
{

    public bool isInRange;
    public UnityEvent interactAtion;
    private bool shouldShowPanel = true;

    // Update is called once per frame
    void Update()
    {
        if (isInRange && shouldShowPanel)
        {
            interactAtion.Invoke();
            shouldShowPanel = false;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            shouldShowPanel = true;
        }
    }
}
