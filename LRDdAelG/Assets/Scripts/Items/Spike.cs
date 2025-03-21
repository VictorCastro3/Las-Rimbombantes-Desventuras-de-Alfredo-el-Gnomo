using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.GetComponent<PlayerMovement>())
            {
                collision.gameObject.GetComponent<PlayerMovement>().Die();
            }
        }
    }
}
