using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    public GameObject body;

    private bool isEnabled;

    public float resetTime;
    private float originalResetTime;

    void Start()
    {
        isEnabled = true;
        originalResetTime = resetTime;
    }

    void Update()
    {
        if (resetTime <= 0)
        {
            if (isEnabled)
            {
                body.SetActive(false);
                isEnabled = false;
            }
            else
            {
                body.SetActive(true);
                isEnabled = true;
            }

            resetTime = originalResetTime;
        }
        else
        {
            resetTime -= Time.deltaTime;
        }
    }
}
