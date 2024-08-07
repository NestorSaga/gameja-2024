using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkScript : MonoBehaviour
{

    Movement movement;

    private void Start()
    {
        movement = FindObjectOfType<Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            movement.NextMovement();
            Destroy(this.gameObject);
        }
    }
}
