using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGumball : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] gumBalls;

    public GameObject projectileDeathEffect;
    public int damageIDealToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = gumBalls[Random.Range(0, gumBalls.Length)];
    }
    // Start is called before the first frame update
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
}
