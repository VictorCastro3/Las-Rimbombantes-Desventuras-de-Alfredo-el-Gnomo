using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.GetComponent<PlayerMovement>())
            {
                //M�todo para da�ar jugador
                Destroy(collision.gameObject);
            }
        }
       
    }
}
