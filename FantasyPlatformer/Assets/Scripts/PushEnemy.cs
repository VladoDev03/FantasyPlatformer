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

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            player.GiveResistance(ResistanceType.Enemy);

            foreach (Patrol enemy in enemies)
            {
                enemy.GetComponent<Rigidbody2D>().gravityScale = 1;
                Destroy(this.gameObject);
            }
        }
    }
}
