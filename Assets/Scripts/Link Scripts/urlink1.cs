using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urlink1 : MonoBehaviour
{
    void FixedUpdate()
    {
        if (GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j.Length > 1)
        {
            transform.localEulerAngles = new Vector3(0f,  (float)(-GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[0]) , 0f);
        }
    }

    void OnApplicationQuit()
    {
        Destroy(this);
    }
}
