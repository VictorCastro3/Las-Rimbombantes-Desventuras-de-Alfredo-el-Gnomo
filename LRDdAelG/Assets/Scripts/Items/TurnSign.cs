using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class TurnSign : MonoBehaviour
{
    private bool turn = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = GameManager.Instance.GetPlayer().GetComponent<PlayerMovement>();
        if (player != null && !turn)
        {
            player.changeDirection();
        }
        turn = !turn;
    }
}
