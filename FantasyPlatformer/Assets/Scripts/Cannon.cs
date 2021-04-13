using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float distance;
    public float offset;

    public float timeBetweenShots;
    private float originalTimeBetweenShots;

    public GameObject bullet;
    public GameObject bulletPosition;
    public GameObject gun;

    private PlayerController player;

    private bool canShoot;

    private void Start()
    {
        canShoot = false;
        originalTimeBetweenShots = timeBetweenShots;
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        Vector3 diff = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        gun.transform.rotation = Quaternion.Euler(0, 0, rotZ + offset);

        if (Vector2.Distance(this.transform.position, player.transform.position) <= distance)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }

        GameObject shot = null;

        if (timeBetweenShots <= 0 && canShoot)
        {
            shot = Instantiate(bullet, bulletPosition.transform.position, gun.transform.rotation);

            timeBetweenShots = originalTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
