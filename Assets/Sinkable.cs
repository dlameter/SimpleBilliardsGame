using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinkable : MonoBehaviour
{
    public GameObject toSink;

    public void sink() {
        Destroy(toSink);
    }
}
