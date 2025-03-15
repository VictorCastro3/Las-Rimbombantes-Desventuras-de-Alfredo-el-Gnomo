using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    [SerializeField]private bool active = true;
    void OnMouseDown()
    {
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
}
