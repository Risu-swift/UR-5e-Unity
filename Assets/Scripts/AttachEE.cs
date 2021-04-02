using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachEE : MonoBehaviour
{
    [SerializeField]private Transform TT;
    [SerializeField]private GameObject eelink;
    private GameObject currentEndEffector;
    private GameObject paddle;
    private bool attached=false;
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("GameObject:" + other.gameObject);
        if(other.gameObject.GetComponent<OVRGrabbable>() != null && other.gameObject.layer == 12 && currentEndEffector == null)
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.SetParent(eelink.transform, false);
            other.gameObject.transform.localPosition = TT.localPosition;
            other.gameObject.transform.localRotation = TT.localRotation;
            paddle = other.gameObject;
            currentEndEffector = other.gameObject;
        }
    }

    private void Update() {
        if(currentEndEffector != null&&attached==false)
        {
            
                // if(currentEndEffector.GetComponent<OVRGrabbable>().isGrabbed)
                //{
                //   currentEndEffector.transform.SetParent(null);
                //}
                //else{
                currentEndEffector.transform.localPosition = TT.localPosition;
             currentEndEffector.transform.localRotation = TT.localRotation;
            if ((currentEndEffector.transform.localPosition == TT.localPosition) && (currentEndEffector.transform.localRotation == TT.localRotation))
            {
                attached = CheckTT();
                Debug.Log("Checked");
            }
            //}
        }   
       
    }
    private bool CheckTT()
    {
        return true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<OVRGrabbable>() != null && other.gameObject.layer == 12&&currentEndEffector!=null)
        {
            Debug.Log("TT Unattached");
            attached = false;

        }
    }
}
