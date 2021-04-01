using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private FinishLevel finishLevel;

    private void Start()
    {
        finishLevel = FindObjectOfType<FinishLevel>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            finishLevel.isUnlocked = true;
            Destroy(this.gameObject);
        }
    }
}
