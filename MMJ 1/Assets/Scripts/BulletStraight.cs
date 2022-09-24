using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStraight : MonoBehaviour
{
    public int amIGoingLeft;
    public float speed;

    public int damageIDealToPlayer;
    public GameObject projectileDeathEffect;

    public Rigidbody2D rb;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("help");
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        rb.velocity = new Vector2(speed * amIGoingLeft, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player");
            PlayerController_2 playerGameObject = collision.gameObject.GetComponent<PlayerController_2>();
            playerGameObject.TakeDamage(damageIDealToPlayer);

            Instantiate(projectileDeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Ground"))
        {
            Debug.Log("ground");
            Instantiate(projectileDeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void LeftOrRight(int goingLeft)
    {
        amIGoingLeft = goingLeft;
    }
}
