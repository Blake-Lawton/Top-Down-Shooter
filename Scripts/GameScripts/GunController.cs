using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public AudioSource gunShot;


    public float timeBetweenShots;
    private float shotCounter;

    public Transform gunPoint;
    // Start is called before the first frame update
    void Start()
    {
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFiring)
        {
            shotCounter -= Time.deltaTime;
            
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                FireGun();
                BulletController newBullet = Instantiate(bullet, gunPoint.position, gunPoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
            }
            
        }
    }

    public void FireGun()
    {
        gunShot.Play();
    }
}
