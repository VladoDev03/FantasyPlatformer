using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(10);

        if (collision.collider.tag == "Player")
        {
            player.GiveBullets();
            Destroy(this.gameObject);
        }
    }
}
