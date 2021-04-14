using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWalk : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.isAbleToWallJump = true;
            Destroy(this.gameObject);
        }
    }
}
