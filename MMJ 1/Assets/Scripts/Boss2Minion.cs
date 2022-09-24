using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Minion : MonoBehaviour
{

    public Transform playerPosition;

    [Header("States")]

    public GameObject gumballAttack;
    public float timeBetweenAttacks;


    public void StartAttack()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        Debug.Log("Get help");
        playerPosition = FindObjectOfType<PlayerController_2>().transform;
        GameObject gumball = Instantiate(gumballAttack, transform.position, Quaternion.identity);
        gumball.GetComponent<GumballBoss2>().whereIGo = playerPosition;
        yield return new WaitForSeconds(timeBetweenAttacks);
        StartCoroutine(Attack());
    }



}
