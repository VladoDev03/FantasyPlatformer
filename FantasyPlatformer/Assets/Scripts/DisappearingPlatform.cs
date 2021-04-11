using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float delay;
    private float originalDelay;

    private bool isAppearing;

    private SpriteRenderer sprite;
    private BoxCollider2D collision;


    void Start()
    {
        originalDelay = delay;
        isAppearing = true;

        collision = this.gameObject.GetComponent<BoxCollider2D>();
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (delay <= 0)
        {
            if (isAppearing)
            {
                isAppearing = false;
                sprite.enabled = false;
                collision.enabled = false;
            }
            else
            {
                isAppearing = true;
                sprite.enabled = true;
                collision.enabled = true;
            }

            delay = originalDelay;
        }
        else
        {
            delay -= Time.deltaTime;
        }
    }
}
