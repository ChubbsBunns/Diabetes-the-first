using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyWrapper : MonoBehaviour
{
    public bool move;
    public float timeToWaitToMove;

    public Rigidbody2D rb;

    [SerializeField] bool facingRight = false;

    public int damageIDealToPlayer;

    public Transform raycastPosition;

    public Animator animator;

    public bool attacking;

    public float timeBetweenAttacks;

    [Header("Movement")]
    public int direction;
    public float speed;

    public GameObject gumball;
    public Transform shooterPosition;
    public bool shootYet;

    //facing
    public float localScaleX;
    // Start is called before the first frame update

    void Start()
    {
        localScaleX = transform.localScale.x;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(NowYouMove());
    }

    // Update is called once per frame
    void Update()
    {
        CheckFacing();
        Flip();
        DetectPlayer();
        Walking();
        Attack();
    }

    IEnumerator NowYouMove()
    {
        yield return new WaitForSeconds(timeToWaitToMove);
        move = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController_2 playerGameObject = collision.gameObject.GetComponent<PlayerController_2>();
            playerGameObject.TakeDamage(damageIDealToPlayer);
        }
        if (collision.CompareTag("Turning Point"))
        {
            changeDirection();
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
    //flipping

    //movement
    public void changeDirection()
    {
        direction *= -1;
    }

    public void Walking()
    {
        if (move == true)
        {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        }
        else
        {
            //stay still
            rb.velocity = new Vector2(0, 0);
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
                move = false;
                attacking = true;
            }
            else
            {
                move = true;
                attacking = false;
            }

        }
        else if (facingRight == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition.position, Vector2.left);
            Debug.DrawRay(raycastPosition.position, Vector2.left);
            if (hit.collider.CompareTag("Player"))
            {
                move = false;
                attacking = true;
            }
            else
            {
                move = true;
                attacking = false;
            }
        }
    }

    public void Attack()
    {
        if (attacking)
        {
            Debug.Log("it happenin");
            if(shootYet)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        GameObject gumball1 = Instantiate(gumball, shooterPosition.position, Quaternion.identity);
        BulletStraight gumballStraight = gumball.GetComponent<BulletStraight>();
        if (facingRight)
        {
            gumballStraight.LeftOrRight(1);
        }
        else
        {
            gumballStraight.LeftOrRight(-1);
        }
        shootYet = false;
        yield return new WaitForSeconds(timeBetweenAttacks);
        shootYet = true;
    }

    //facing

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
}
