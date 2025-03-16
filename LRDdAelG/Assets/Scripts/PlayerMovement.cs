using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float springJump = 10f;
    [SerializeField] float bumperY = 1.5f;
    [SerializeField] float bumperX = 5f;
    [SerializeField] float fanY = 1.25f;
    [SerializeField] float fanX = 1.25f;
    [SerializeField] float launchForce = 7f;
    public ParticleSystem particlesystem;

    private bool respawnTiming = false;
    private float timer = 0f;
    private GameObject child;
    private Animator animator;
    [SerializeField]
    private Deaths d;

    private Rigidbody2D rb;
    private int direction = 1;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.GivePlayer(gameObject);
        rb = gameObject.GetComponent<Rigidbody2D>();
        child = gameObject.transform.GetChild(0).gameObject;
        animator = child.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        d = FindObjectOfType<Deaths>();
        if (respawnTiming)
        {
            canMove = false;
            timer += Time.deltaTime;
            if (timer >= 1.45f)
            {
                respawnTiming = false;
                timer = 0f;
                GameManager.Instance.RespawnPlayer();
                animator.SetBool("defeated", false);
                canMove = true;
                direction *= 1;
                gameObject.transform.rotation *= Quaternion.Euler(0, 180, 0);
            }
        }
        if (speed > 0 && canMove)
        {
            gameObject.transform.position += new Vector3(speed * Time.deltaTime * direction, 0, 0);
        }
        animator.SetBool("isWalking", canMove);
        animator.SetBool("isAir", rb.velocity.y != 0);
    }
    public void changeDirection()
    {
        gameObject.transform.rotation *= Quaternion.Euler(0, 180, 0);
        direction *= -1;
    }
    public void JumpSpring()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, springJump), ForceMode2D.Impulse);
    }
    public void JumpBumper(int i)
    {
        rb.velocity = new Vector3(0, 0, 0);
        if (direction != i)
        {
            changeDirection();
        }
        rb.AddForce(new Vector2(bumperX * direction, bumperY), ForceMode2D.Impulse);
    }
    public void AirPush(int i)
    {
        switch (i)
        {
            case 0:
                rb.velocity = new Vector2(-fanX, rb.velocity.y);
                break;
            case 1:
                rb.velocity = new Vector2(fanX, rb.velocity.y);
                break;
            case 2:
                rb.velocity = new Vector2(rb.velocity.x, fanY);
                break;
            case 3:
                rb.velocity = new Vector2(rb.velocity.x, -fanY);
                break;
        }
    }
    public void Launched(float rotationAngle, Vector2 upVector)
    {
        if (rotationAngle > 0)
        {
            if (direction != -1)
            {
                changeDirection();
            }
        }
        else
        {
            if (direction != 1)
            {
                changeDirection();
            }
        }
        rb.AddForce(upVector * launchForce, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Ground"))
        {
            changeDirection();
            Debug.Log("Cambia dirección");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        StopSign stopSign = collision.GetComponent<StopSign>();
        if (collision != null && stopSign != null && stopSign.IsActive())
        {
            canMove =false;
            particlesystem.Stop();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StopSign stopSign = collision.GetComponent<StopSign>();
        if (collision != null && stopSign != null)
        {
            canMove =true;
        }
    }
    public void NowCanMove()
    {
        canMove = true;
        particlesystem.Play();
    }
    public void Die()
    {
        d.DeathSound();
        animator.SetBool("defeated", true);
        respawnTiming = true;
        canMove = false;

    }
    public void Restart()
    {
            respawnTiming = false;
            timer = 0f;
            GameManager.Instance.RespawnPlayer();
            animator.SetBool("defeated", false);
            canMove = true;
            direction *= 1;
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
