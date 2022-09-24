using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    //index for unlocks
    // 1: double jump
    // 2: wall slide
    // 3: Dash
    public int unlockIndex;
    public GameManagementLogs gameLogs;
    public PlayerController_2 player;

    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        gameLogs = FindObjectOfType<GameManagementLogs>();
        player = FindObjectOfType<PlayerController_2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (unlockIndex == 1)
            {
                gameLogs.maxNoOfJumpsForPlayer = 2;
                player.maxNumberOfJumpsPermitted = 2;
                player.currentAvailableJumps = 2;

                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            if (unlockIndex == 2)
            {
                gameLogs.dashUnlocked = true;
                player.ableToDash = true;

                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            if (unlockIndex == 3)
            {
                gameLogs.wallSlideUnlocked = true;
                player.ableToWallSlide = true;

                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
