using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    void Update()
    {
        this.transform.Translate(new Vector2(bulletSpeed * Time.deltaTime, 0));
    }
}
