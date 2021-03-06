using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hapticfeedback : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.collider.gameObject.layer == 10)
        {
            OVRInput.SetControllerVibration(0.3f,0.5f,OVRInput.GetActiveController());
        }
    }
}
