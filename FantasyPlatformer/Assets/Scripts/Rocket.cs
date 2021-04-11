using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float timeBeforeDestroy = 3;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.collider.tag == "Bullet")
        {
            Debug.Log(collision.collider.gameObject.tag);
            Destroy(collision.collider.gameObject);
            Destroy(this.gameObject);
        }
    }
}
