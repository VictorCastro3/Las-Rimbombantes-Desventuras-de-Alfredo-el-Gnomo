using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spring : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = GameManager.Instance.GetPlayer().GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.JumpSpring();
        }
    }
}
