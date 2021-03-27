using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachEE : MonoBehaviour
{
    [SerializeField]private GameObject eelink;
    private GameObject currentEndEffector;
    private void OnTriggerEnter(Collider other) {
        Debug.Log("GameObject:" + other.gameObject);
        if(other.gameObject.GetComponent<OVRGrabbable>() != null && other.gameObject.layer == 12)
        {
            
            other.gameObject.transform.SetParent(eelink.transform, false);
            currentEndEffector = other.gameObject;
        }
    }

    private void Update() {
        if(currentEndEffector != null)
        {
        if(currentEndEffector.GetComponent<OVRGrabbable>().isGrabbed)
        {
            currentEndEffector.transform.SetParent(null);
        }}   
    }
}
