using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyonthrow : MonoBehaviour
{
    public GameObject here;
    bool exit = false;
    private GameObject currentobject;

    // Start is called before the first frame update
    void Start()
    {
        // here = GameObject.Find("respawn_point");
    }

    // Update is called once per frame
    void Update()
    {
        if (exit)
        {
            currentobject.transform.position = currentobject.transform.parent.position;
            //
        }
        exit = false;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.layer == 11 || other.GetComponent<Collider>().gameObject.layer == 12)
        {
            currentobject = other.GetComponent<Collider>().gameObject;
            exit = true;

            // Destroy(other.GetComponent<Collider>().gameObject);

            Debug.Log("Destroyed");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.layer == 11)
        {
            exit = false;
            Debug.Log("Respawned");
        }
    }
}
