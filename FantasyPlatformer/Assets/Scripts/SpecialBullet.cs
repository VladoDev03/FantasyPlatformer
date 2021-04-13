using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    public float speed;

    private float timeBeforeDestroy = 3;

    private PlayerController player;
    private Vector2 target;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        target = player.transform.position;
    }

    void Update()
    {
        if (Vector2.Distance(target, this.transform.position) == 0)
        {
            Destroy(this.gameObject);
        }

        this.transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

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
