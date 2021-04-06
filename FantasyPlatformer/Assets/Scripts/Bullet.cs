using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timeBeforeDestroy = 3;
    public float bulletSpeed;

    void Update()
    {
        this.transform.Translate(new Vector2(bulletSpeed * Time.deltaTime, 0));

        if (timeBeforeDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timeBeforeDestroy -= Time.deltaTime;
        }
    }
}
