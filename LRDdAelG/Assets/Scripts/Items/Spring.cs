using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spring : MonoBehaviour
{
    private Animator animator; 
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = GameManager.Instance.GetPlayer().GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.JumpSpring();
            animator.SetTrigger("activated");
        }
    }
}
