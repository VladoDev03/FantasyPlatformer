using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.AddExtraJumps(1);
            Destroy(this.gameObject);
        }
    }
}
