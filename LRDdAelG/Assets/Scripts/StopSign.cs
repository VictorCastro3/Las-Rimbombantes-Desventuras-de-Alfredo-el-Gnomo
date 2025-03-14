using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float stopTime = 2.0f;
    [SerializeField] float timerstoptime;
    [SerializeField] bool touched;
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*OnTriggerEnter2D (); 
        if (touched == true)
        {
            PlayerMovement.Instance.Stopspeed();
            timerstoptime += Time.deltaTime;
            if (timerstoptime > stopTime)
            {
                PlayerMovement.Instance.ResumeSpeed();
                touched = false;
                timerstoptime = 0; 
                
            }

        }
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Player")) 
        {
            PlayerMovement.Instance.StopSpeed();
            touched = true;
        }
        */
    }

}
