using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoss2 : MonoBehaviour
{
    public int damageIDealToPlayer;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController_2 playerGameObject = collision.gameObject.GetComponent<PlayerController_2>();
            playerGameObject.TakeDamage(damageIDealToPlayer);
        }
    }
}
