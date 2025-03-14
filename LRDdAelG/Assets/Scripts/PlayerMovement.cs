using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float springJump = 10f;

    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.GivePlayer(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(speed * Time.deltaTime * direction, 0, 0);
    }

    public void changeDirection()
    {
        gameObject.transform.rotation *= Quaternion.Euler(0, 180, 0);
        direction *= -1;
    }
    public void JumpSpring()
    {
        gameObject.transform.position += new Vector3(0, springJump, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            changeDirection();
            Debug.Log("Cambia direcci�n");
        }
    }
}
