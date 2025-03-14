using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                Destroy(gameObject);
            }
            else if (collision.gameObject.GetComponent<PlayerMovement>())
            {
                //Método para dañar jugador
                Destroy(gameObject);
            }
        }
       
    }
}
