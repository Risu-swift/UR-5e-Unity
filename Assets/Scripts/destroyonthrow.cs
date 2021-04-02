using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyonthrow : MonoBehaviour
{
    //public GameObject here;
    bool exit;
    private GameObject currentobject;

    // Start is called before the first frame update
    void Start()
    {
        // here = GameObject.Find("respawn_point");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (exit)
        {
            respawn();
            Debug.Log("UPDATE EXIT TRUE");
            //currentobject.transform.position = currentobject.transform.parent.position;
           /* if (currentobject.transform.position == currentobject.transform.parent.position)
            {
                exit = false;
            }*/

        }
        





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
    /*void OnTriggerEnter(Collider other)
    {
        if (exit)
        {
            if (other.GetComponent<Collider>().gameObject.layer == 11 || other.GetComponent<Collider>().gameObject.layer == 12)
            {
                exit = false;
                Debug.Log("Respawned");
            }
        }
    }*/
    private void respawn()
    {
        Debug.Log("Respawned");
        currentobject.transform.position = currentobject.transform.parent.position;
        exit = false;
    }
}
