using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urlink1 : MonoBehaviour
{
    void FixedUpdate()
    {
        if (GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j.Length > 1 && GlobalVariables_Main_Control.isAuto && GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[0] >= 0f)
        {
            transform.localEulerAngles = new Vector3(0f,  (float)(-GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[0]) , 0f);
        }
        else if(LinkRotator.joints.Count > 1 && !GlobalVariables_Main_Control.isAuto)
        {
            transform.localEulerAngles = new Vector3(0f,  (float)(-LinkRotator.joints[0]*Mathf.Rad2Deg) , 0f);
        }
    }

    void OnApplicationQuit()
    {
        Destroy(this);
    }
}
