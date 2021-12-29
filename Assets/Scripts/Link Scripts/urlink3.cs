using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urlink3 : MonoBehaviour
{
    void FixedUpdate()
    {
        if (GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j.Length > 1)
        {
            transform.localEulerAngles = new Vector3( (float) (GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[2]),0f, 0f);
        }
    }

    void OnApplicationQuit()
    {
        Destroy(this);
    }
}
