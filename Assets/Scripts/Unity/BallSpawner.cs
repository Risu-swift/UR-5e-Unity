using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private Rigidbody rb;
    private PPBall ball;
    public float VelocityScale;
    private bool triggerButton;
    public interfaceActivator ur5trigger;

    private bool isButtonPressed = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GetComponent<PPBall>();
        ur5trigger = GameObject.Find("Controll").transform.GetChild(2).GetComponent<interfaceActivator>();
    }

    void Update()
    {
        if(ur5trigger.entered)
        {
            triggerButton = false;

        }
        else
        {
            isButtonPressed = Input.GetKeyDown("space");
            triggerButton = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
        }
        
            
       
        // Input.GetAxis("Axis1D.PrimaryIndexTrigger");
    }

    private void FixedUpdate()
    {
        if (isButtonPressed||triggerButton)
        {
            rb.position = new Vector3(-1.5f, 1.5f, 0.0f);
            rb.velocity = new Vector3(2.5f*VelocityScale, Random.Range(3.0f, 3.75f)*VelocityScale,
                                        Random.Range(-0.5f, 0.5f)*VelocityScale);
            ball.setState(1);
        }
    }
}
