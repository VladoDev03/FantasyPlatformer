using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float timeBetweenShots;
    private float originalTimeBetweenShots;
    public GameObject bullet;
    public GameObject bulletPosition;

    private void Start()
    {
        originalTimeBetweenShots = timeBetweenShots;
    }

    private void Update()
    {
        GameObject shot = null;

        if (timeBetweenShots <= 0)
        {
            shot = Instantiate(bullet, bulletPosition.transform.position, this.transform.rotation);

            //shot.transform.position = new Vector2(bulletSpeed, 0);

            timeBetweenShots = originalTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
