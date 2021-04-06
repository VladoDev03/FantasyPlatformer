using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    public float timeBetweenShots;
    private float originalTimeBetweenShots;
    public GameObject rocket;
    public GameObject rocketPosition;

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
        if (Vector2.Distance(this.transform.position, player.transform.position) <= 3)
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
            shot = Instantiate(rocket, rocketPosition.transform.position, this.transform.rotation);

            timeBetweenShots = originalTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
