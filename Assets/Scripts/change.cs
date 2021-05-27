using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change : MonoBehaviour
{
    public GameObject shoulder;
    private ArticulationBody tar;

    // Start is called before the first frame update
    void Start()
    {
        tar = shoulder.GetComponent<ArticulationBody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void test()
    {
        var tarXDrive = tar.xDrive;
        tarXDrive.target=0;
    }
}
