using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumballBoss2 : MonoBehaviour
{
    public PlayerController_2 player;
    public Transform whereIGo;
    public float speed;

    public float lifespan;

    public GameObject projectileDeathEffect;

    public int damageIDealToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController_2>();
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate()
    {
        LeggoAttack(whereIGo);
    }

    public void LeggoAttack(Transform positionNow)
    {
        transform.position = Vector2.MoveTowards(transform.position, whereIGo.position, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("ground");
            Instantiate(projectileDeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player");
            PlayerController_2 playerGameObject = collision.gameObject.GetComponent<PlayerController_2>();
            playerGameObject.TakeDamage(damageIDealToPlayer);

            Instantiate(projectileDeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
