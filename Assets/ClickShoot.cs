using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickShoot : MonoBehaviour
{
    public GameObject mainBall;
    public AudioSource ballHitSound;

    public Camera playerCamera;

    public GameObject linePrefab;
    private GameObject lineInstance;

    public float maxHitPower;
    public float stopThreshold;

    private bool charging = false;

    private Vector3 aimDirection;

    // Update is called once per frame
    void Update()
    {
        if (isStopped(mainBall.GetComponent<Rigidbody2D>())) {
            if (charging) {
                this.showCharger(aimDirection, getChargeAmount(aimDirection, getVecFromBallToMouse()));
            }
            else {
                this.showAimer();
            }

            if (Input.GetMouseButtonDown(0)) {
                if (charging) {
                    hitBall(aimDirection.normalized, getChargeAmount(aimDirection, getVecFromBallToMouse()) * maxHitPower);
                    charging = false;
                }
                else {
                    aimDirection = getVecFromBallToMouse();
                    charging = true;
                }
            }
            else if (Input.GetMouseButtonDown(1)) {
                if (charging) {
                    charging = false;
                }
            }
        }
        else {
            this.hideAimer();
        }
    }

    private bool isStopped(Rigidbody2D body) {
        return withinThreshold(body.velocity.magnitude, stopThreshold);
    }

    private void showAimer() {
        Vector3 start = mainBall.transform.position;
        Vector3 end = getMousePosWorld();
        drawLineFromTo(start, end);
    }

    private void hideAimer() {
        if (lineInstance != null) {
            Destroy(lineInstance);
        }
    }

    private void showCharger(Vector3 aim, float charge) {
        Vector3 end = mainBall.transform.position + (aim * charge);
        drawLineFromTo(mainBall.transform.position, end);
    }

    private void drawLineFromTo(Vector3 from, Vector3 to) {
        if (lineInstance == null) {
            lineInstance = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        }

        LineRenderer lineRen = lineInstance.GetComponent<LineRenderer>();
        lineRen.SetPositions(new Vector3[] {from, to});
    }

    private bool withinThreshold(float value, float threshold) {
        return Mathf.Abs(value) < threshold;
    }

    private float getChargeAmount(Vector3 aim, Vector3 mousePosCurrent) {
        float charge = mousePosCurrent.magnitude / aim.magnitude;
        return charge > 1 ? 1 : charge;
    }

    private Vector3 getVecFromBallToMouse() {
        Vector3 mousePos = getMousePosWorld();
        return (mousePos - mainBall.transform.position);
    }

    private Vector3 getMousePosWorld() {
        Vector3 mousePos = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = mainBall.transform.position.z;
        return mousePos;
    }

    private void hitBall(Vector3 direction, float power) {
        ballHitSound.Play();
        mainBall.GetComponent<Rigidbody2D>().AddForce(direction * power);
    }
}
