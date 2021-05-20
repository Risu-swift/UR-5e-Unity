using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interfaceActivator : MonoBehaviour
{
    public GameObject interfacepanel;
    public bool entered = false;
    // Start is called before the first frame update
    void Start()
    {
        interfacepanel = GameObject.Find("Interface");
        //interfacepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="CamRig")
        {
            entered = true;
            Debug.Log("ENTER");
            interfacepanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "CamRig")
        {
            entered = false;
            interfacepanel.SetActive(false);
        }
    }
}
