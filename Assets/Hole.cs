using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BallCenter")
        {
            Sinkable sinkable;
            if ((sinkable = other.GetComponent<Sinkable>()) != null)
            {
                sinkable.sink();
            }
        }
    }
}
