using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCaneEnemy : MonoBehaviour
{
    public Rigidbody2D rb;

    public float walkSpeed;
    public float chargeSpeed;

    public bool facingRight;

    public int direction;

    public int damageIDealToPlayer;

    public Transform raycastPosition;

    public Animator animator;

    [Header("States")]
    public bool walking = true;
    public bool charging = false;

    public float localScaleX;

    public Transform[] patrolPoints;
    // Start is called before the first frame update
    void Start()
    {
        localScaleX = transform.localScale.x;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        CheckFacing();
        Flip();
        Move();
    }

    public void CheckFacing()
    {
        if (rb.velocity.x > 0)
        {
            facingRight = true;
        }
        if (rb.velocity.x < 0)
        {
            facingRight = false;
        }
    }

    public void Walking()
    {
        rb.velocity = new Vector2(walkSpeed * direction, rb.velocity.y);
    }

    public void Charging()
    {
        rb.velocity = new Vector2(chargeSpeed * direction, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            walking = false;
            charging = true;
        }

        if (collision.CompareTag("Turning Point"))
        {
            changeDirection();
        }

        if (collision.tag == "Player")
        {
            PlayerController_2 playerGameObject = collision.gameObject.GetComponent<PlayerController_2>();
            playerGameObject.TakeDamage(damageIDealToPlayer);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            walking = true;
            charging = false;
        }
    }


    public void Move()
    {
        if(walking)
        {
            Walking();
        }
        if(charging)
        {
            Charging();
        }
    }

    public void changeDirection()
    {
        direction *= -1;
    }

    void Flip()
    {
        if (facingRight)
        {
            transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        }

        else if (facingRight == false)
        {
            transform.localScale = new Vector3(-localScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    public void DetectPlayer()
    {
        if (facingRight)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition.position, Vector2.right);
            Debug.DrawRay(raycastPosition.position, Vector2.right);
            if (hit.collider.CompareTag("Player"))
            {
                animator.SetBool("Charging", true);
                walking = false;
                charging = true;
            }
            else
            {
                animator.SetBool("Charging", false);
                walking = true;
                charging = false;
            }

        }
        else if (facingRight == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition.position, Vector2.left);
            Debug.DrawRay(raycastPosition.position, Vector2.left);
            if (hit.collider.CompareTag("Player"))
            {
                animator.SetBool("Charging", true);
                walking = false;
                charging = true;
            }
            else
            {
                animator.SetBool("Charging", false);
                walking = true;
                charging = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController_2 playerGameObject = collision.gameObject.GetComponent<PlayerController_2>();
            playerGameObject.TakeDamage(damageIDealToPlayer);
        }
    }
}
