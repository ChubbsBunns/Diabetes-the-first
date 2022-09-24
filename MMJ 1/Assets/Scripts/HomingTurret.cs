using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingTurret : MonoBehaviour
{
    public GameObject bullet;
    public GameObject[] gumBalls;
    public int timeBetweenBulletInstantiation;
    public int maxNumberOfGumballs;
    public GameObject gumBallToInstantiate;

    public Transform gumballShooterPosition1;
    public Transform gumballShooterPosition2;
    // Start is called before the first frame update
    void Start()
    {
        maxNumberOfGumballs = gumBalls.Length;
        StartCoroutine(generateBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator generateBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBetweenBulletInstantiation);
        StartCoroutine(generateBullet());
    }
}
