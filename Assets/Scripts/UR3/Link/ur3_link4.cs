// ------------------------------------------------------------------------------------------------------------------------//
// ----------------------------------------------------- LIBRARIES --------------------------------------------------------//
// ------------------------------------------------------------------------------------------------------------------------//

// -------------------- Unity -------------------- //

using System;
using UnityEngine;
using RosSharp.Control;
using UnityEngine.UI;

public class ur3_link4 : MonoBehaviour
{
    private ArticulationDrive currentJoint;
    private ArticulationBody chain;
    private Controller _controller;
    private bool clicked = false;
    public int joint;
    public Toggle _Toggle;
    private void Start()
    {
        chain = this.gameObject.GetComponent<ArticulationBody>();
        _controller = GetComponentInParent<Controller>();
        

    }

    


    void FixedUpdate()
    {
        currentJoint = chain.gameObject.GetComponent<JointControl>().joint.xDrive;
        currentJoint.target = GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[3];
        currentJoint.stiffness = _controller.stiffness;
        currentJoint.damping = _controller.damping;
        chain.gameObject.GetComponent<JointControl>().joint.xDrive = currentJoint;
      
    }

    
    
}