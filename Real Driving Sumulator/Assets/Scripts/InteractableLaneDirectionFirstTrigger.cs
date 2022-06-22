using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableLaneDirectionFirstTrigger : MonoBehaviour
{
    public UnityEvent interactAtion;
    public LaneDirectionScript laneDirectionScript;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            laneDirectionScript.UpdateFirstTriggerEntered(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            laneDirectionScript.UpdateFirstTriggerEntered(false);
        }
    }

}
