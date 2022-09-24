using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyFast : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public int currentPointIndex;
    public bool move;
    public float timeToWaitToMove;

    public float timeToWaitToMoveAgain;

    public int maxPoint;

    public Rigidbody2D rb;

    [SerializeField] bool facingRight = false;

    public int damageIDealToPlayer;
    // Start is called before the first frame update
    private void Awake()
    {
        transform.position = patrolPoints[0].position;
    }

    void Start()
    {
        maxPoint = patrolPoints.Length;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(NowYouMove());
    }

    // Update is called once per frame
    void Update()
    {
        DoIFlip();
        if (move == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
            if (transform.position == patrolPoints[currentPointIndex].position)
            {
                if (currentPointIndex + 1 < patrolPoints.Length)
                {
                    if (currentPointIndex == 0)
                    {
                        StartCoroutine(NowYouMoveAgain());
                        Flip();
                    }
                    currentPointIndex++;
                }
                else
                {
                    Flip();
                    StartCoroutine(NowYouMoveAgain());
                    currentPointIndex = 0;
                }
            }
        }
    }

    IEnumerator NowYouMove()
    {
        yield return new WaitForSeconds(timeToWaitToMove);
        move = true;
    }

    IEnumerator NowYouMoveAgain()
    {
        move = false;
        yield return new WaitForSeconds(timeToWaitToMoveAgain);
        move = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController_2 playerGameObject = collision.gameObject.GetComponent<PlayerController_2>();
            playerGameObject.TakeDamage(damageIDealToPlayer);
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
    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }

    void DoIFlip()
    {

    }
}
