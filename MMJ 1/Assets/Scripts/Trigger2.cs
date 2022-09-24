using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    public bool done;

    Boss2 boss2;
    public WallBoss2 wallBoss1;
    public WallBoss2 wallBoss2;

    public Boss2Minion[] boss2Minions;
    // Start is called before the first frame update
    void Start()
    {
        boss2 = FindObjectOfType<Boss2>();
        boss2Minions = FindObjectsOfType<Boss2Minion>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (done)
        {
            wallBoss1.doorsAreClosed = true;
            wallBoss2.doorsAreClosed = true;

            boss2.Attacking();

            for (int i = 0; i < boss2Minions.Length; i++)
            {
                boss2Minions[i].StartAttack();
            }
            done = false;
        }
    }
}
