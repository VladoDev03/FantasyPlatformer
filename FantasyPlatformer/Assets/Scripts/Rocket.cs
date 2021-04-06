using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private float timeBeforeDestroy = 30;
    public float rocketSpeed;

    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, rocketSpeed * Time.deltaTime);

        if (timeBeforeDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timeBeforeDestroy -= Time.deltaTime;
        }
    }
}
