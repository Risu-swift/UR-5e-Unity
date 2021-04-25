using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private Rigidbody rb;
    private PPBall ball;
    public float VelocityScale;
    private float triggerButton;

    private bool isButtonPressed = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GetComponent<PPBall>();
    }

    void Update()
    {
        isButtonPressed = Input.GetKeyDown("space");
        triggerButton = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);// Input.GetAxis("Axis1D.PrimaryIndexTrigger");
    }

    private void FixedUpdate()
    {
        if (isButtonPressed||triggerButton==1.0)
        {
            rb.position = new Vector3(-1.5f, 1.5f, 0.0f);
            rb.velocity = new Vector3(2.5f*VelocityScale, Random.Range(3.0f, 3.75f)*VelocityScale,
                                        Random.Range(-0.5f, 0.5f)*VelocityScale);
            ball.setState(1);
        }
    }
}
