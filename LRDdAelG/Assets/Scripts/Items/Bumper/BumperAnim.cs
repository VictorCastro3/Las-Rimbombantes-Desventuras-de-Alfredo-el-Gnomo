using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperAnim : MonoBehaviour
{
    private Animator animator;
    private float timer = 0f;
    private bool activo = false;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (timer >= 0.3f && activo)
        {
            animator.SetBool("active", false);
            timer = 0f;
            activo = false;
        }
        else if (activo)
        {
            timer += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("raaaah");
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            animator.SetBool("active", true);
            activo = true;
        }
    }
}
