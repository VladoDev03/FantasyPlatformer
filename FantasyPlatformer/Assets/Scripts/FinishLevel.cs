using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public bool isUnlocked;
    private Key key;

    private void Start()
    {
        isUnlocked = true;
        key = FindObjectOfType<Key>();

        if (key != null)
        {
            isUnlocked = false;
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
