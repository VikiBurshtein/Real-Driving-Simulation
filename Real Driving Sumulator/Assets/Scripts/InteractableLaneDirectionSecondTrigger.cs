using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableLaneDirectionSecondTrigger : MonoBehaviour
{
    public UnityEvent interactAtion;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactAtion.Invoke();
        }
    }
}
