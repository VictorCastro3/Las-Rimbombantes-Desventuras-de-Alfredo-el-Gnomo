using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    private Animator animator; 
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    [SerializeField]private bool active = true;
    void OnMouseDown()
    {
        if (active)
        {
            animator.SetInteger("state", 0);
        }
        else
        {
            animator.SetInteger("state", 1);
        }
        active = !active;
        if (!active)
        {
        PlayerMovement player = GameManager.Instance.GetPlayer().GetComponent<PlayerMovement>();
        player.NowCanMove();
        }
    }
    public bool IsActive()
    {
        return active;
    }
    public void Restart()
    {
        active = true;
        animator.SetInteger("state", 1);
    }
}
