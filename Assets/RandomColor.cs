using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public GameObject spriteToColor;

    // Start is called before the first frame update
    void Start()
    {
        Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        SpriteRenderer renderer = spriteToColor.GetComponent<SpriteRenderer>();
        renderer.color = color;
    }
}
