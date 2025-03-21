using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperRight : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            player.JumpBumper(1);
        }
    }
}
