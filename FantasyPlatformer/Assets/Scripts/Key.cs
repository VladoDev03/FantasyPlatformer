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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            finishLevel.requiredKeys--;
            Destroy(this.gameObject);
        }
    }
}
