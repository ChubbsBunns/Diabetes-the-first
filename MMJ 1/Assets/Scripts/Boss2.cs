using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    [Header("Health")]
    public float enemyHealth;
    public GameObject deathEffect;
    public GameObject hurtEffect;

    [Header("Wall stuff")]
    public WallBoss2 wall1;
    public WallBoss2 wall2;

    [Header("States")]
    public bool waiting;
    public bool attacking;

    [Header("Timing")]
    public int timeBetweenAttack2;
    public int timeForAttack2;

    [Header("Core components")]
    public Animator anim;

    [Header("Controller")]
    public bool attack2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

    public void Attacking()
    {
        StartCoroutine(AttackCandyCane());
    }

    IEnumerator AttackCandyCane()
    {
        anim.SetBool("AttackCandyCane", false);
        yield return new WaitForSeconds(timeBetweenAttack2);
        anim.SetBool("AttackCandyCane", true);
        yield return new WaitForSeconds(timeForAttack2);
        StartCoroutine(AttackCandyCane());
        attack2 = false;
    }
}
