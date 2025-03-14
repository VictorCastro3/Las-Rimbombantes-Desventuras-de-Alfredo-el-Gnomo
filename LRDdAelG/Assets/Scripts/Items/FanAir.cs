using UnityEngine;

public class FanAir : MonoBehaviour
{
    [SerializeField] int direction = 0;//0 izq, 1 der, 2 arr, 3 abj
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            player.AirPush(direction);
        }
    }
}