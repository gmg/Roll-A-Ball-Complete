using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private float knockbackStrength = 5.0f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Vector3 direction = collision.GetContact(0).normal;
            var movement = collision.gameObject.GetComponent<PlayerMovement>();
            if (movement != null)
            {
                movement.Push(-direction, knockbackStrength);
            }
        }
    }
}
