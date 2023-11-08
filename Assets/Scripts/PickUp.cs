using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public static event Action OnPickUpCollected;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            OnPickUpCollected?.Invoke();
        }
    }
}
