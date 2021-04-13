using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEnemy : MonoBehaviour
{
    private PlayerController player;
    private Patrol[] enemies;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        enemies = FindObjectsOfType<Patrol>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GiveResistance(ResistanceType.Enemy);

            if (enemies != null)
            {
                foreach (Patrol enemy in enemies)
                {
                    if (enemy != null)
                    {
                        enemy.GetComponent<Rigidbody2D>().gravityScale = 1;
                    }
                }
            }

            Destroy(this.gameObject);
        }
    }
}
