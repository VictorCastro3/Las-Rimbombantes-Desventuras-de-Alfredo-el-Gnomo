using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class TurnSign : MonoBehaviour
{
    private bool turn = false;
    private Animator animator; 
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = GameManager.Instance.GetPlayer().GetComponent<PlayerMovement>();
        if (player != null && !turn)
        {
            player.changeDirection();
        }
    }
    public void Deactivated()
    {
        turn = true;
        animator.SetInteger("state", 1);
    }
}
