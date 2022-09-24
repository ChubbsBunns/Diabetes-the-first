using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBear : MonoBehaviour
{
    [Header("Wall stuff")]
    public WallBoss wall1;
    public WallBoss wall2;

    [Header("States")]
    public bool idle;
    public bool attack1;
    public bool anticipation;
    public bool attack2;

    [Header("Core Components")]
    public Rigidbody2D rb;
    public Animator anim;
    public float chargeSpeed;
    public int damageIDealToPlayer;

    //charge attack = index 1
    // ground pound = index 2
    public int previousAttackIndex;

    [Header("timings")]
    public float chargeTime;
    public float groundPoundTime;
    public float anticipationTime;

    public bool timingAttack1;
    public bool timingAttack2;
    public bool timingAnticipation;

    public int direction;

    [Header("Facing")]
    public bool facingRight;
    public float localScaleX;

    [Header("GroundPound")]
    public Dropme[] gumballGenerators;

    [Header ("Health")]
    public float enemyHealth;
    public GameObject deathEffect;
    public GameObject hurtEffect;

    public GameManagementLogs logs;
    // Start is called before the first frame update
    private void Awake()
    {
        logs = FindObjectOfType<GameManagementLogs>();
        if (logs.boss1Dead)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        localScaleX = transform.localScale.x;
        gumballGenerators = FindObjectsOfType<Dropme>();
        anim = GetComponent<Animator>();
        direction = -1;
        idle = true;
        attack1 = false;
        attack2 = false;
        anticipation = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (attack1)
        {
            Charging();
        }
        if (anticipation)
        {
            Anticipation();
        }
        if (attack2)
        {
            GroundPound();
        }
        if (idle)
        {
            Waiting();
        }
        CheckFacing();
    }

    public void Charging()
    {
        anim.SetBool("isCharging", true);
        anim.SetBool("isAnticipating", false);
        rb.velocity = new Vector2(chargeSpeed * direction, rb.velocity.y);
        if (timingAttack1)
        {
            StartCoroutine(Attack1(chargeTime));
        }

        //set an ienumerator to set anticipation to true again
    }

    public void Waiting()
    {
        rb.velocity = new Vector2(0, 0);
    }

    public void Anticipation()
    {
        anim.SetBool("isCharging", false);
        anim.SetBool("isGroundPound", false);
        anim.SetBool("isAnticipating", true);
        rb.velocity = new Vector2(0, 0);
        //i wait ffs until i choose an attack aft waiting time
        if (timingAnticipation)
        {
            StartCoroutine(AnticipateHowLong(anticipationTime));
        }
        //set a IENUMERATOR function to set anticipation to false and one of the waiting or ground pound attacks to be true
    }

    public void GroundPound()
    {
        anim.SetBool("isGroundPound", true);
        anim.SetBool("isAnticipating", false);
        rb.velocity = new Vector2(0, 0);
        if (timingAttack2)
        {
            StartCoroutine(Attack2(groundPoundTime));
        }
        //input instantiate debri over here
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Turning Point"))
        {
            ChangeDirection();
            Flip();
        }

        if (collision.tag == "Player")
        {
            PlayerController_2 playerGameObject = collision.gameObject.GetComponent<PlayerController_2>();
            playerGameObject.TakeDamage(damageIDealToPlayer);
        }
    }

    public void ChangeDirection()
    {
        direction *= -1;
    }

    IEnumerator AnticipateHowLong(float time)
    {
        timingAnticipation = false;
        //waiting for anticipation to start
        yield return new WaitForSeconds(time);
        if (previousAttackIndex == 1)
        {
            attack2 = true;
        }
        if (previousAttackIndex == 2)
        {
            attack1 = true;
        }
        anticipation = false;
        timingAnticipation = true;

    }

    IEnumerator Attack1(float time)
    {
        timingAttack1 = false;
        yield return new WaitForSeconds(time);
        previousAttackIndex = 1;
        attack1 = false;
        timingAttack1 = true;
        anticipation = true;
        Debug.Log("efstdhfukh");
    }

    IEnumerator Attack2(float time)
    {
        attack2 = true;
        timingAttack2 = false;
        yield return new WaitForSeconds(time);
        previousAttackIndex = 2;
        attack2 = false;
        anticipation = true;
        timingAttack2 = true;
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

    public void CreateDebri()
    {

            for (int i = 0; i < gumballGenerators.Length; i++)
            {
                gumballGenerators[i].CreateAGumball();
            }
    }

    public void enemyTakeDamage(int playerDamage)
    {
        enemyHealth -= playerDamage;
        if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
            wall1.doorsAreClosed = false;
            wall2.doorsAreClosed = false;
            Destroy(gameObject);
        }
        else
        {
            Instantiate(hurtEffect, gameObject.transform.position, Quaternion.identity);
        }
    }
}
