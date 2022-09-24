using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropme : MonoBehaviour
{
    public GameObject gumball;

    public void CreateAGumball()
    {
        Instantiate(gumball, transform.position, Quaternion.identity);
    }
}
