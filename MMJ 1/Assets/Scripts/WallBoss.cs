using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBoss : MonoBehaviour
{
    public bossBear boss1;

    public Transform doorsOpenPosition;
    public Transform doorsClosedPosition;

    public bool doorsAreClosed;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        doorsAreClosed = false;
        boss1 = FindObjectOfType<bossBear>();
    }

    // Update is called once per frame
    void Update()
    {
        CloseTheDoors();
        OpenTheDoors();
    }

    public void CloseTheDoors()
    {
        if (doorsAreClosed)
        {
            transform.position = Vector2.MoveTowards(transform.position, doorsClosedPosition.position, speed);
        }
    }

    public void OpenTheDoors()
    {
        if (doorsAreClosed == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, doorsOpenPosition.position, speed);
        }
    }

}
