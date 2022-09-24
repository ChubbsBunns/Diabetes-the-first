using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    bossBear boss1;
    public WallBoss wallBoss1;
    public WallBoss wallBoss2;
    // Start is called before the first frame update
    void Start()
    {
        boss1 = FindObjectOfType<bossBear>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        boss1.idle = false;
        boss1.attack1 = true;
        boss1.anim.SetBool("isIdle", false);

        wallBoss1.doorsAreClosed = true;
        wallBoss2.doorsAreClosed = true;
    }
}
