using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public int requiredKeys;
    public bool isUnlocked;
    private Key[] keys;

    private void Start()
    {
        isUnlocked = true;
        keys = FindObjectsOfType<Key>();

        if (requiredKeys == 0)
        {
            isUnlocked = false;
        }

        requiredKeys = keys.Length;
    }

    private void Update()
    {
        if (requiredKeys == 0)
        {
            isUnlocked = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player" && isUnlocked == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
