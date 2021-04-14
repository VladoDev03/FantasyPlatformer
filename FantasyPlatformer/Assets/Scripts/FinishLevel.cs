using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    public int requiredKeys;
    public int enemiesToKill;

    public bool areEnemiesRequired;

    private bool enemiesAreKilled;
    private bool isUnlocked;

    private Key[] keys;
    private Patrol[] enemies;

    private int requirementsCount;

    public Text keysText;
    public Text enemiesText;

    private void Start()
    {
        enemiesAreKilled = false;
        isUnlocked = false;

        keys = FindObjectsOfType<Key>();

        if (areEnemiesRequired)
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

        requirementsCount = GetRequirementsCount();
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

        string[] statsData = ShowStats(requiredKeys, enemiesToKill);

        keysText.text = statsData[0];
        enemiesText.text = statsData[1];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player" && isUnlocked == true && enemiesAreKilled == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private int GetRequirementsCount()
    {
        int count = 0;

        if (areEnemiesRequired == true)
        {
            count++;
        }

        if (requiredKeys > 0)
        {
            count++;
        }

        return count;
    }

    private string[] ShowStats(int keys, int enemies)
    {
        if (keys < 0)
        {
            keys = 0;
        }

        if (enemies < 0)
        {
            enemies = 0;
        }

        string[] stats = new string[]
        {
            $"Keys: {keys}",
            $"Enemies: {enemies}"
        };

        return stats;
    }
}
