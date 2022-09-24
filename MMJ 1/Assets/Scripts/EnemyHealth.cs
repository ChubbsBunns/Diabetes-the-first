using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public GameObject deathEffect;
    public GameObject hurtEffect;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(gameObject);
        }
        else
        {
            Instantiate(hurtEffect, gameObject.transform.position, Quaternion.identity);
        }
    }
}
