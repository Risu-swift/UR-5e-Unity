using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interfaceActivator : MonoBehaviour
{
    public GameObject interfacepanel;
    // Start is called before the first frame update
    void Start()
    {
        interfacepanel = GameObject.Find("Interface");
        interfacepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="CamRig")
        {
            Debug.Log("ENTER");
            interfacepanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "CamRig")
        {
            interfacepanel.SetActive(false);
        }
    }
}
