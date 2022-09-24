using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivalPoint : MonoBehaviour
{
    public PlayerController_2 player;

    public GameManagementLogs logs;

    public int maxHealth;

    public bool active;

    public Animator anim;

    public string myCurrentScene;
    // Start is called before the first frame update
    private void Awake()
    {
        logs = FindObjectOfType<GameManagementLogs>();
        anim = GetComponent<Animator>();
        if (logs.reviveMe)
        {
            player = FindObjectOfType<PlayerController_2>();
            logs.PutMeHere(transform);
            logs.CreateVirtualCamera(transform);
            logs.reviveMe = false;
        }
        else
        {
            return;
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("helpeaksgmhty");
            anim.SetBool("ActiveRevivalPoint", true);
            collision.GetComponent<PlayerController_2>().health = maxHealth;
            active = true;
            logs.sceneNameToLoadOnDeath = myCurrentScene;
        }
    }
}
