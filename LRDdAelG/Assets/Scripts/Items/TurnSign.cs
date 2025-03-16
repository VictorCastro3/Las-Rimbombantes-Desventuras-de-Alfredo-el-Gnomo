using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class TurnSign : MonoBehaviour
{
    private bool turn = false;
    private bool activatetime = false;
    private float timer = 0f;
    private Animator animator; 
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (activatetime){
            timer += Time.deltaTime;
            if (timer >= 0.4f)
            {
                timer = 0f;
                activatetime = false;
            }
        }
    }
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     PlayerMovement player = GameManager.Instance.GetPlayer().GetComponent<PlayerMovement>();
    //     if (player != null && !turn && !activatetime)
    //     {
    //         player.changeDirection();
    //         activatetime = true;
    //     }
    //     {
    //         player.changeDirection();
    //     }
    // }
    public void Deactivated()
    {
        this.tag = "Untagged";
        animator.SetInteger("state", 1);
    }
    public void Reactivate()
    {
        this.tag = "Ground";
        animator.SetInteger("state", 0);
    }
}
