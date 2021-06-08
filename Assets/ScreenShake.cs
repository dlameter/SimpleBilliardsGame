using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float magnitude = 0.7f;
    public float damping = 1.0f;
    public Camera childCamera;

    private float shakeDuration = 0;

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            this.ShakeScreen();
        }

        this.DoShake();
    }

    public void ShakeScreen() {
        shakeDuration = 1;
    }

    public void ShakeScreen(float value) {
        ShakeScreen();
        magnitude = value;
    }

    private void DoShake() {
        if (shakeDuration > 0) {
            childCamera.transform.localPosition = Random.insideUnitSphere * magnitude;
            shakeDuration -= Time.deltaTime * damping;
        }
        else {
            childCamera.transform.localPosition = Vector3.zero;
        }
    }
}
