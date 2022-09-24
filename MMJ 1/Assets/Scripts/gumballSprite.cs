using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gumballSprite : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] gumBalls;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = gumBalls[Random.Range(0, gumBalls.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
