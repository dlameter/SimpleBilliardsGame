using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnImpact : MonoBehaviour
{
    public ScreenShake shaker;

    public float maxShakeDuration = 0.7f;
    public float minShakeDuration = 0;
    public float velocityThreshold = 2;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > velocityThreshold)
        {
            shaker.ShakeScreen(mapFloat(collision.relativeVelocity.magnitude, 0, 20, minShakeDuration, maxShakeDuration));
        }
    }

    float mapFloat(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }
}
