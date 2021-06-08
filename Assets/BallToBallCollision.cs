using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallToBallCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip ballClip;
    public AudioClip wallClip;
    public float volumeMultiplier;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        if (collision.gameObject.tag == "Ball") {
            audioSource.volume = map(collision.relativeVelocity.magnitude, 0, 10, 0, 1) * volumeMultiplier;
            audioSource.PlayOneShot(ballClip);
        }
        audioSource.volume = 1.0f;
        audioSource.PlayOneShot(wallClip);
    }

    float map( float value, float leftMin, float leftMax, float rightMin, float rightMax )
    {
        return rightMin + ( value - leftMin ) * ( rightMax - rightMin ) / ( leftMax - leftMin );
    }
}
