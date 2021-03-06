using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask layer;

    private bool movingRight = true;

    public Transform groundDetection;

    private FinishLevel finishLevel;

    private void Start()
    {
        finishLevel = FindObjectOfType<FinishLevel>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, layer);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.layer == 9)
        {
            Destroy(this.gameObject);
            finishLevel.enemiesToKill--;
        }
        if (collision.collider.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            finishLevel.enemiesToKill--;
        }
        if (collision.collider.gameObject.tag == "Laser")
        {
            Destroy(this.gameObject);
            finishLevel.enemiesToKill--;
        }
        if (collision.collider.gameObject.tag == "Rocket")
        {
            Destroy(this.gameObject);
            finishLevel.enemiesToKill--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(this.gameObject);
            finishLevel.enemiesToKill--;
        }
    }
}
