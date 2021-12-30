using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urlink6 : MonoBehaviour
{
    void Update()
    {
        if (GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j.Length > 1 && GlobalVariables_Main_Control.isAuto) 
        {
            transform.localEulerAngles = new Vector3( (float) (GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[5]),0f, 0f);
        }
        else if (LinkRotator.joints.Count > 1 && !GlobalVariables_Main_Control.isAuto)
        {
            transform.localEulerAngles = new Vector3( (float) (LinkRotator.joints[5]*Mathf.Rad2Deg),0f, 0f);
        }
    }

    void OnApplicationQuit()
    {
        Destroy(this);
    }
}
