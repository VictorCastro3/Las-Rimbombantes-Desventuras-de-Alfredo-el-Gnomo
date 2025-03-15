using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    private bool stopped = true;
    private PlayerMovement playerMovement = GameManager.Instance.GetPlayer().GetComponent<PlayerMovement>();
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
        if (stopped && Input.GetMouseButtonDown(0)) 
        {
            ChangeState();
        }

        if (!stopped)
        {
           playerMovement.CanPlayerMove(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null && stopped)
        {
            Debug.Log("WAIT, then Click");
            playerMovement.CanPlayerMove(false);
        }
    }

    private void ChangeState()
    {
        stopped = !stopped;
    }

}
