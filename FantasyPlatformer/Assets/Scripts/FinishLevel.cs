using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public int requiredKeys;
    public int enemiesToKill;

    public bool isEnemiesRequired;

    private bool enemiesAreKilled;
    private bool isUnlocked;

    private Key[] keys;
    private Patrol[] enemies;

    private void Start()
    {
        enemiesAreKilled = false;
        isUnlocked = false;

        keys = FindObjectsOfType<Key>();

        if (isEnemiesRequired)
        {
            enemies = FindObjectsOfType<Patrol>();
            enemiesToKill = enemies.Length;

            if (enemiesToKill > 0)
            {
                enemiesAreKilled = false;
            }
        }

        requiredKeys = keys.Length;

        if (requiredKeys > 0)
        {
            isUnlocked = false;
        }
    }

    private void Update()
    {
        if (requiredKeys == 0)
        {
            isUnlocked = true;
        }
        if (enemiesToKill == 0)
        {
            enemiesAreKilled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player" && isUnlocked == true && enemiesAreKilled == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
