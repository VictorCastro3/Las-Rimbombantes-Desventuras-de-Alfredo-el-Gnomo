using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReverseButton : MonoBehaviour
{
        void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = GameManager.Instance.GetPlayer().GetComponent<PlayerMovement>();
        if (player != null)
        {
            TurnSign[] turnSigns = FindObjectsOfType<TurnSign>();
            foreach (TurnSign turnSign in turnSigns)
            {
                turnSign.Deactivated();
            }
        }
    }
}
