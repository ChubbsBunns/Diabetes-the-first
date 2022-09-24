using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysTurret : MonoBehaviour
{
    public GameObject bullet;
    public GameObject[] gumBalls;
    public int timeBetweenBulletInstantiation;
    public int maxNumberOfGumballs;
    public GameObject gumBallToInstantiate;

    public Transform gumballShooterPosition1;
    public Transform gumballShooterPosition2;

    public int gumBallsStillAlive;
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
        GameObject bullet1 = Instantiate(bullet, gumballShooterPosition1.position, Quaternion.identity);
        GameObject bullet2 = Instantiate(bullet, gumballShooterPosition2.position, Quaternion.identity);
        BulletStraight bulletStraight1 = bullet1.GetComponent<BulletStraight>();
        bulletStraight1.LeftOrRight(-1);
        BulletStraight bulletStraight2 = bullet2.GetComponent<BulletStraight>();
        bulletStraight2.LeftOrRight(1);
        yield return new WaitForSeconds(timeBetweenBulletInstantiation);
        StartCoroutine(generateBullet());
    }
}
