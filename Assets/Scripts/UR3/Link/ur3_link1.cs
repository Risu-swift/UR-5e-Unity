// ------------------------------------------------------------------------------------------------------------------------//
// ----------------------------------------------------- LIBRARIES --------------------------------------------------------//
// ------------------------------------------------------------------------------------------------------------------------//

// -------------------- Unity -------------------- //

using System;
using UnityEngine;
using RosSharp.Control;
using UnityEngine.UI;

public class ur3_link1 : MonoBehaviour
{
    private ArticulationDrive currentJoint;
    private ArticulationBody chain;
    private Controller _controller;
    private bool clicked = false;
    public int joint;
   
    private bool isChecked;
    private void Start()
    {
        chain = this.gameObject.GetComponent<ArticulationBody>();
        _controller = GetComponentInParent<Controller>();
        
    }
    void FixedUpdate()
    {
                
            currentJoint = chain.gameObject.GetComponent<JointControl>().joint.xDrive;
            if (joint == 1)
            {
                currentJoint.target = GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[0];
            }

            if (joint == 2)
            {
                currentJoint.target = GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[1];
            }

            if (joint == 3)
            {
                currentJoint.target = GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[2];
            }

            if (joint == 4)
            {
                currentJoint.target = GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[3];
            }

            if (joint == 5)
            {
                currentJoint.target = GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[4];
            }

            if (joint == 6)
            {
                currentJoint.target = GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[5];
            }

            currentJoint.stiffness = _controller.stiffness;
            currentJoint.damping = _controller.damping;
            chain.gameObject.GetComponent<JointControl>().joint.xDrive = currentJoint;
            Debug.Log("value" + GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[0]);
        
    }
    void OnApplicationQuit() {
        Destroy(this);
    }

    

    
    
}
